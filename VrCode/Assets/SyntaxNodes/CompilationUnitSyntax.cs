using NodeComponents;
using UnityEngine;

namespace SyntaxNodes
{
    public class CompilationUnitSyntax : CSharpSyntaxNode
    {
        public override void Attach(Node other)
        {
            Debug.Log("clicked");

            if (other.SyntaxNode is Microsoft.CodeAnalysis.CSharp.Syntax.UsingDirectiveSyntax selectedUsing)
            {
                var newNode = ((Microsoft.CodeAnalysis.CSharp.Syntax.CompilationUnitSyntax) SyntaxNode).AddUsings(selectedUsing);
                RootNode.ReplaceNode(SyntaxNode, newNode);

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