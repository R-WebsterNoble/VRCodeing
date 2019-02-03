using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.SyntaxNodes;
using JetBrains.Annotations;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using UnityEngine;

namespace Assets
{
    public class RootNode : Node
    {
        public Node SelectedNode;

        private SyntaxNode _rootNode;
        //private Dictionary<SyntaxNode, GameObject> _nodes = new Dictionary<SyntaxNode, GameObject>();

        void Update()
        {
            if (SelectedNode == null)
                return;

            if (Input.GetKeyUp(KeyCode.Delete))
            {
                _rootNode = _rootNode.RemoveNode(SelectedNode.SyntaxNode, SyntaxRemoveOptions.KeepExteriorTrivia);
                Destroy(Children.First().gameObject);
                Children = new List<Node>(new[] {CreateTree(_rootNode)});
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            _rootNode = new CodeEditor().Gen().GetRoot();
            Children.Add(CreateTree(_rootNode));
            //InstantiateNode(gameObject.transform, helloWorld.GetRoot());

            //var memberAccessNode = (MemberAccessExpressionSyntax)helloWorld.GetRoot().ChildNodes().ElementAt(1)
            //    .ChildNodes().ElementAt(1).ChildNodes().First().ChildNodes().ElementAt(2).ChildNodes().First()
            //    .ChildNodes().First().ChildNodes().First();

            //var node = _nodes[memberAccessNode].;
            //_nodes.TryGetValue(node.Parent, out var ga);

            //var syntaxNodeParent = ga.GetComponent<Node>().SyntaxNode.Parent;
            //_nodes.TryGetValue(syntaxNodeParent, out var ga2);
        }
    }
}
