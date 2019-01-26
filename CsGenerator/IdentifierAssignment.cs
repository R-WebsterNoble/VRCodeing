using CsGenerator.Expression;

namespace CsGenerator
{
    public class IdentifierAssignment : IExpression
    {
        public Identifier Identifier { get; }

        public IdentifierAssignment(Identifier identifier)
        {
            Identifier = identifier;
        }

        public override string ToString()
        {
            return $"{Identifier.Type} {Identifier.Name} = {Identifier.O}";
        }
    }
}