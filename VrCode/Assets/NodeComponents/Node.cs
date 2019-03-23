using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.CodeAnalysis;
using UnityEngine;

namespace NodeComponents
{
    public abstract partial class Node : MonoBehaviour
    {
        public List<Node> Children { get; set; } = new List<Node>();
        public Node Parent { get; set; }
        public Node RootNode { get; set; }

        public SyntaxNode SyntaxNode { get; set; }
        public LineRenderer Line;

        public Draggable Draggable;

        [UsedImplicitly]
        private void Awake()
        {
            if(Draggable == null)
            {
                Draggable = gameObject.AddComponent<Draggable>();
            }
            Draggable.Node = this;
        }

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

            SetPosition(nodeScript);

            nodeScript.InitComponents();

            nodeScript.AttachChildren(node.ChildNodes());

            return nodeScript;
        }

        public virtual void InitComponents()
        {
            var displayName = DisplayString;
            name = GetType().ToString().Replace("SyntaxNodes.", "");

            InitVisualComponents(displayName);

            InitLine();
        }

        // null root to make this a new root
        public static Node InstantiateSyntaxNode(SyntaxNode rosNode, [CanBeNull] Node rootNode)
        {
            GameObject newNode;
            Node nodeScript;

            var nodeName = rosNode.GetType().ToString()
                .Replace("Microsoft.CodeAnalysis.CSharp.Syntax.", "");

            var nodePrefab = Resources.Load("SyntaxNodePrefabs/" + nodeName);

            if(nodePrefab != null)
            {
                newNode = (GameObject)Instantiate(nodePrefab, rootNode?.transform);
                nodeScript = newNode.GetComponent<Node>();
            }
            else
            {
                newNode = new GameObject();
                var type = SyntaxNodeLookup.LookupType(rosNode);
                nodeScript = (Node)newNode.AddComponent(type);
                //var nodeScript = newNode.GetComponent<Node>();

                var rigidBody = newNode.AddComponent<Rigidbody>();
                rigidBody.isKinematic = true;
            }

            nodeScript.RootNode = rootNode ?? nodeScript;
            nodeScript.SyntaxNode = rosNode;

            return nodeScript;
        }

        public void ReplaceNode(SyntaxNode oldNode, SyntaxNode newNode)
        {
            if (RootNode != this)
                throw new Exception("Only call ReplaceNode on Root Node");

            var newTreeRoot = SyntaxNode.ReplaceNode(oldNode, newNode);
            RebuildTree(newTreeRoot);
        }

        public void RebuildTree(SyntaxNode newRootNode)
        {
            SyntaxNode = newRootNode;
            foreach (var child in Children)
                if (child != null && child.gameObject != null)
                    Destroy(child.gameObject);

            Height = 1;
            Children = new List<Node>();
            AttachChildren(newRootNode.ChildNodes());
        }

        public virtual void Attach(Node other)
        {
        }

        //private void DeleteTree()
        //{
        //    foreach (var child in Children)
        //    {
        //        DeleteTree();
        //    }
        //}

        public void Detach()
        {
            try
            {
                var newRootNode = RootNode.SyntaxNode.RemoveNode(SyntaxNode, SyntaxRemoveOptions.KeepExteriorTrivia);
                Parent.Children.Remove(this);
                RootNode.RebuildTree(newRootNode);
                RootNode = this;
                Parent = null;
                Line = null;
                transform.parent = null;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}