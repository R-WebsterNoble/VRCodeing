namespace SyntaxNodes
{
    public class LiteralExpressionSyntax : ExpressionSyntax
    {
        public override string DisplayString =>
            ((Microsoft.CodeAnalysis.CSharp.Syntax.LiteralExpressionSyntax) SyntaxNode).Token.ToString()
            .Replace("\n", "");
    }
}