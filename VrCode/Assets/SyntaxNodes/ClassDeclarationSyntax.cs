using NodeComponents;
using UnityEngine;

namespace SyntaxNodes
{
    public class ClassDeclarationSyntax : TypeDeclarationSyntax
    {
        public GameObject NameAp;
        public GameObject BodyAp;

        public override string DisplayString =>
            "class " + ((Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax) SyntaxNode).Identifier.ValueText;

        public override void InitComponents()
        {
            name = DisplayString;
            GetComponentInChildren<TextMesh>().text = DisplayString;

            NameAp.GetComponent<AttachmentPoint>().Attached += AttachName;
            BodyAp.GetComponent<AttachmentPoint>().Attached += AttachBody;
        }

        private void AttachBody(object sender, Node bodyNode)
        {
            var member = bodyNode.SyntaxNode as Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax;
            if (member == null)
                return;

            var newNode = ((Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax) SyntaxNode).AddMembers(member);

            RootNode.ReplaceNode(SyntaxNode, newNode);

            if (bodyNode.gameObject != null)
                Destroy(bodyNode.gameObject);
        }

        private void AttachName(object sender, Node nameNode)
        {
            var identifier = nameNode.SyntaxNode as Microsoft.CodeAnalysis.CSharp.Syntax.IdentifierNameSyntax;
            if (identifier == null)
                return;

            var newNode =
                ((Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax) SyntaxNode).WithIdentifier(identifier
                    .Identifier);

            RootNode.ReplaceNode(SyntaxNode, newNode);

            GetComponentInChildren<TextMesh>().text = DisplayString;

            if (nameNode.gameObject != null)
                Destroy(nameNode.gameObject);
        }
    }
}