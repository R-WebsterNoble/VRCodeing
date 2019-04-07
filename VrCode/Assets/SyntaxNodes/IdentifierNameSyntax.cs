using System;
using Microsoft.CodeAnalysis.CSharp;
using NodeComponents;
using UnityEngine;

namespace SyntaxNodes
{
    public class IdentifierNameSyntax : SimpleNameSyntax
    {
        public override string DisplayString =>
            ((Microsoft.CodeAnalysis.CSharp.Syntax.IdentifierNameSyntax) SyntaxNode).Identifier.ValueText;

        public override void InitComponents()
        {
            name = DisplayString;
            GetComponentInChildren<TextMesh>().text = DisplayString;

            //var thing = (GameObject) Instantiate(Resources.Load("IdentifierName"), transform);
            //thing.name = "IdentifierNamePrefab";

            //thing.GetComponentInChildren<TextMesh>().text = ((Microsoft.CodeAnalysis.CSharp.Syntax.IdentifierNameSyntax) SyntaxNode).ToString();

            ////Draggable.Anchor = thing.gameObject.GetComponentInParent<Anchor>()?.AnchorObj;
        }

        public override void Attach(Node other, AttachmentPoint ap)
        {
            Debug.Log("clicked");

            if (other.SyntaxNode is Microsoft.CodeAnalysis.CSharp.Syntax.IdentifierNameSyntax)
            {
                try
                {
                    var newNode = SyntaxFactory.ParseName(DisplayString + "." + other.DisplayString);
                    RootNode.ReplaceNode(SyntaxNode, newNode);
                }
                catch (Exception e)
                {
                    Debug.Log($"Couldn't attach {other.DisplayString} to {DisplayString}: {e.Message}");
                    return;
                }

                //var line = gameObject.AddComponent<LineRenderer>();
                //line.material = new Material(Shader.Find("Unlit/Texture"));
                //line.startColor = Color.grey;
                //line.endColor = Color.grey;
                //line.startWidth = 0.1f;
                //line.endWidth = 0.1f;
                //line.SetPositions(new[] { transform.position, transform.position + new Vector3(-0.25f, 0f, 0f) });

                //Line = line;
                if (other.gameObject != null)
                    Destroy(other.gameObject);
            }
            else
            {
                Debug.Log($"Couldn't attach {other.DisplayString} to {DisplayString}");
            }
        }
    }
}