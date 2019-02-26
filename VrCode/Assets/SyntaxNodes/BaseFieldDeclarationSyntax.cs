namespace SyntaxNodes
{
    public class BaseFieldDeclarationSyntax : MemberDeclarationSyntax
    {
        public override int Height { get; set; } = 0;
        public override string DisplayString => "";
    }
}