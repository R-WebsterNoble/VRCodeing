using JetBrains.Annotations;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using UnityEngine;

public class UsingFactory : MonoBehaviour
{
    [UsedImplicitly]
    void OnMouseDown()
    {
        UsingDirectiveSyntax name = SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(""));
        var node = Node.InstantiateSyntaxNode(name, null);
        node.InitComponents(null);

        node.gameObject.transform.position = gameObject.transform.position;
        node.gameObject.transform.Translate(0,10,0);
    }
}