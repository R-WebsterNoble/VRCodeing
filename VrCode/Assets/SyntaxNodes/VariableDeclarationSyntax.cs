namespace SyntaxNodes
{
    public class VariableDeclarationSyntax : CSharpSyntaxNode
    {
        public override string DisplayString =>
            ((Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclarationSyntax) SyntaxNode).Variables.FirstOrDefault()
            .Identifier.Text;
    }
}