using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.CodeAnalysis;
using UnityEngine;

public class RootNode : Node
{
    public Node SelectedNode;

    //private Dictionary<SyntaxNode, GameObject> _nodes = new Dictionary<SyntaxNode, GameObject>();

    [UsedImplicitly]
    void Update()
    {
        if (SelectedNode == null)
            return;

        if (Input.GetKeyUp(KeyCode.Delete))
        {
            var newRootNode = SyntaxNode.RemoveNode(SelectedNode.SyntaxNode, SyntaxRemoveOptions.KeepExteriorTrivia);
            RebuildTree(newRootNode);
        }
    }

    public void RebuildTree(SyntaxNode newRootNode)
    {
        SyntaxNode = newRootNode;
        Destroy(Children.First().gameObject);

        var newTree = new[]
        {
            CreateTree(SyntaxNode)
        };

        Children = new List<Node>(newTree);
    }

    // Start is called before the first frame update
        
    [UsedImplicitly]
    void Start()
    {
        SyntaxNode = new CodeEditor().Gen().GetRoot();
        Children.Add(CreateTree(SyntaxNode));
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