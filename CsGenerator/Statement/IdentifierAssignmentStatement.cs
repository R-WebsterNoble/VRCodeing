namespace CsGenerator.Statement
{
    public class IdentifierAssignmentStatement : IStatement, IClassItem
    {
        public IdentifierAssignment Identifier { get; }

        public IdentifierAssignmentStatement(IdentifierAssignment identifier)
        {
            Identifier = identifier;
        }

        public override string ToString()
        {
            return $"{Identifier};";
        }
    }
}