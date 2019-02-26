namespace SyntaxNodes
{
    public class PredefinedTypeSyntax : TypeSyntax
    {
        public override string DisplayString =>
            ((Microsoft.CodeAnalysis.CSharp.Syntax.PredefinedTypeSyntax) SyntaxNode).Keyword.ValueText;
    }
}