using JetBrains.Annotations;
using Microsoft.CodeAnalysis.CSharp;
using NodeComponents;
using UnityEngine;

namespace SyntaxFactories
{
    public class UsingFactory : MonoBehaviour
    {
        [UsedImplicitly]
        private void OnMouseDown()
        {
            var name = SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(""));
            var node = Node.InstantiateSyntaxNode(name, null);
            node.InitComponents();

            node.gameObject.transform.position = gameObject.transform.position;
            node.gameObject.transform.Translate(0, 10, 0);
        }
    }
}