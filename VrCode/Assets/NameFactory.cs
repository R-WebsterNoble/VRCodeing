using JetBrains.Annotations;
using Microsoft.CodeAnalysis.CSharp;
using UnityEngine;

public class NameFactory : MonoBehaviour
{
    [UsedImplicitly]
    void OnMouseDown()
    {
        var text = GameObject.FindGameObjectWithTag("Voice").GetComponent<TextMesh>().text;

        var nameRosNode = SyntaxFactory.ParseName(text);

        var node = Node.InstantiateSyntaxNode(nameRosNode, null);

        node.gameObject.transform.position = gameObject.transform.position;
        node.gameObject.transform.Translate(0,10,0);
    }
}