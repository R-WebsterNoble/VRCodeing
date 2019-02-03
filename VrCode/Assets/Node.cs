using System.Collections.Generic;
using Assets.SyntaxNodes;
using Microsoft.CodeAnalysis;
using UnityEngine;

namespace Assets
{
    public abstract class Node : MonoBehaviour
    {
        public virtual int Height { get; set; } = 1;
        public SyntaxNode SyntaxNode { get; set; }
        public Transform Parent { get; set; }
        public List<Node> Children { get; set; } = new List<Node>();
        public LineRenderer Line { get; set; }

        public Vector3 screenPoint;
        public Vector3 offset;

        public virtual string DisplayString => SyntaxNode.GetType().ToString()
            .Replace("Microsoft.CodeAnalysis.CSharp.Syntax.", "")
            .Replace("Syntax", "");

        public virtual void AttachChildren(IEnumerable<SyntaxNode> nodes)
        {
            foreach (var childNode in nodes)
            {
                var newChildNode = CreateTree(childNode);
                Height += newChildNode.Height;
                Children.Add(newChildNode);
            }
        }

        public virtual Node CreateTree(SyntaxNode node)
        {
            var newNode = new GameObject();
            var type = SyntaxNodeLookup.LookupType(node);
            var nodeScript = (Node)newNode.AddComponent(type);

            nodeScript.SyntaxNode = node;
            nodeScript.Parent = transform;

            var displayName = nodeScript.DisplayString;
            newNode.name = nodeScript.GetType().ToString().Replace("Assets.SyntaxNodes.", "");

            newNode.transform.parent = transform;
            newNode.transform.localPosition = new Vector3(1, Height  * - 2, 0);

            var text = newNode.AddComponent<TextMesh>();
            text.text = displayName;
            var box = newNode.AddComponent<BoxCollider>();

            var textBounds = text.GetComponent<Renderer>().bounds;
            box.size = textBounds.size;

            var line = newNode.AddComponent<LineRenderer>();
            line.material = new Material(Shader.Find("Unlit/Texture"));
            line.startColor = Color.grey;
            line.endColor = Color.grey;
            line.startWidth = 0.1f;
            line.endWidth = 0.1f;
            line.SetPositions(new[] { newNode.transform.position, transform.position + new Vector3(-0.25f, 0f, 0f) });
            nodeScript.Line = line;

            nodeScript.AttachChildren(node.ChildNodes());

            return nodeScript;
        }

        void OnMouseDown()
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

            var root = GameObject.FindGameObjectWithTag("GameController").GetComponent<RootNode>();
            root.SelectedNode = this;
        }

        void OnMouseDrag()
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            transform.position = curPosition;

            UpdateLine();
        }

        public void UpdateLine()
        {
            Line.SetPositions(new[] { transform.position, Parent.position });
            foreach (var child in Children)
            {
                child.UpdateLine();
            }
        }

        //private void DeleteTree()
        //{
        //    foreach (var child in Children)
        //    {
        //        DeleteTree();
        //    }
        //}
    }
}