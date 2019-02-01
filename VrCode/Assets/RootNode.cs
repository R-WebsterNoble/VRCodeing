using System;
using System.Collections;
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
        //private Dictionary<SyntaxNode, GameObject> _nodes = new Dictionary<SyntaxNode, GameObject>();


        // Start is called before the first frame update
        void Start()
        {
            var helloWorld = new CodeEditor().Gen().GetRoot();
            CreateNode(helloWorld);
            //InstantiateNode(gameObject.transform, helloWorld.GetRoot());

            //var memberAccessNode = (MemberAccessExpressionSyntax)helloWorld.GetRoot().ChildNodes().ElementAt(1)
            //    .ChildNodes().ElementAt(1).ChildNodes().First().ChildNodes().ElementAt(2).ChildNodes().First()
            //    .ChildNodes().First().ChildNodes().First();

            //var node = _nodes[memberAccessNode].;
            //_nodes.TryGetValue(node.Parent, out var ga);

            //var syntaxNodeParent = ga.GetComponent<Node>().SyntaxNode.Parent;
            //_nodes.TryGetValue(syntaxNodeParent, out var ga2);
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}
