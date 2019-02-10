using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.CodeAnalysis;
using SyntaxNodes;
using UnityEngine;

public abstract class Node : MonoBehaviour
{
    public virtual int Height { get; set; } = 1;
    public SyntaxNode SyntaxNode { get; set; }
    public Transform Parent { get; set; }
    public List<Node> Children { get; set; } = new List<Node>();
    public LineRenderer Line { get; set; }
    public Node RootNode { get; set; }

    public Vector3 ScreenPoint;
    public Vector3 Offset;

    public virtual string DisplayString => SyntaxNode.GetType().ToString()
        .Replace("Microsoft.CodeAnalysis.CSharp.Syntax.", "")
        .Replace("Syntax", "");

    public virtual void AttachChildren(IEnumerable<SyntaxNode> nodes)
    {
        foreach (var childNode in nodes)
        {
            var newChildNode = CreateTree(childNode, RootNode);
            Height += newChildNode.Height;
            Children.Add(newChildNode);
        }
    }

    public virtual Node CreateTree(SyntaxNode node, Node rootNode)
    {
        var nodeScript = InstantiateSyntaxNode(node, rootNode);

        nodeScript.Parent = transform;
        nodeScript.gameObject.transform.parent = transform;
        nodeScript.gameObject.transform.localPosition = new Vector3(1, Height  * - 2, 0);

        nodeScript.InitComponents(this);

        nodeScript.AttachChildren(node.ChildNodes());

        return nodeScript;
    }

    public virtual void InitComponents(Node parent)
    {
        var displayName = DisplayString;
        name = GetType().ToString().Replace("Assets.SyntaxNodes.", "");

        var text = gameObject.AddComponent<TextMesh>();
        text.text = displayName;
        var box = gameObject.AddComponent<BoxCollider>();

        var textBounds = text.GetComponent<Renderer>().bounds;
        box.size = textBounds.size;

        InitLine(parent);
    }

    public virtual void InitLine(Node parent)
    {
        var line = gameObject.AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Unlit/Texture"));
        line.startColor = Color.grey;
        line.endColor = Color.grey;
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.SetPositions(new[] {gameObject.transform.position, parent.transform.position + new Vector3(-0.25f, 0f, 0f)});
        Line = line;
    }

    // null root to make this a new root
    public static Node InstantiateSyntaxNode(SyntaxNode rosNode, [CanBeNull] Node rootNode) 
    {
        var newNode = new GameObject();
        var type = SyntaxNodeLookup.LookupType(rosNode);
        var nodeScript = (Node) newNode.AddComponent(type);

        nodeScript.RootNode = rootNode?? nodeScript;
        nodeScript.SyntaxNode = rosNode;

        return nodeScript;
    }

    [UsedImplicitly]
    public void OnMouseDown()
    {
        ScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        Offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenPoint.z));

        var root = GameObject.FindGameObjectWithTag("GameController").GetComponent<RootNode>();
        root.SelectedNode = this;
    }

    [UsedImplicitly]
    public void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + Offset;

        transform.position = curPosition;

        UpdateLine();
    }

    public void UpdateLine()
    {
        if (Line != null)
            Line.SetPositions(new[] {transform.position, Parent.position});

        foreach (var child in Children)
        {
            child.UpdateLine();
        }
    }

    public void ReplaceNode(SyntaxNode oldNode, SyntaxNode newNode)
    {
        if(RootNode != this)
            throw new Exception("Only call ReplaceNode on Root Node");
        var newTreeRoot = SyntaxNode.ReplaceNode(oldNode, newNode);
        RebuildTree(newTreeRoot);
    }

    public void RebuildTree(SyntaxNode newRootNode)
    {
        SyntaxNode = newRootNode;
        foreach (var child in Children)
        {
            if(child != null && child.gameObject != null)
                Destroy(child.gameObject);
        }

        Height = 1;
        Children = new List<Node>();
        AttachChildren(newRootNode.ChildNodes());
    }

    //private void DeleteTree()
    //{
    //    foreach (var child in Children)
    //    {
    //        DeleteTree();
    //    }
    //}
}