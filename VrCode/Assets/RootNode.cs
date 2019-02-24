using System;
using JetBrains.Annotations;
using Microsoft.CodeAnalysis;
using NodeComponents;
using SyntaxNodes;
using UnityEngine;

public class RootNode : CompilationUnitSyntax
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
            if (SelectedNode.RootNode == SelectedNode)
            {
                Destroy(SelectedNode.gameObject);
                SelectedNode = null;
                return;
            }

            try
            {
                var newRootNode = SyntaxNode.RemoveNode(SelectedNode.SyntaxNode, SyntaxRemoveOptions.KeepExteriorTrivia);
                RebuildTree(newRootNode);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }

    // Start is called before the first frame update
        
    [UsedImplicitly]
    void Start()
    {
        RootNode = this;
        SyntaxNode = new CodeEditor().Gen().GetRoot();
        RebuildTree(SyntaxNode);
        //Children.Add(CreateTree(SyntaxNode, this));
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