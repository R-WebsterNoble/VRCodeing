using JetBrains.Annotations;
using Microsoft.CodeAnalysis.CSharp;
using NodeComponents;
using UnityEngine;

namespace SyntaxFactories
{
    public class NamespaceFactory : MonoBehaviour
    {
        [UsedImplicitly]
        private void OnMouseDown()
        {
            var text = GameObject.FindGameObjectWithTag("Voice").GetComponent<TextMesh>().text;

            var nameRosNode = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(text));

            var node = Node.InstantiateSyntaxNode(nameRosNode, null);

            node.InitComponents(null);

            node.gameObject.transform.position = gameObject.transform.position;
            node.gameObject.transform.Translate(0, 10, 0);
        }
    }
}