using System.Collections.Generic;
using CsGenerator.Expression;

namespace CsGenerator.Statement.Loop
{
    public class ForEachLoop : IStatement
    {
        public IdentifierAssignment Identifier { get; }
        public IExpression Expression { get; }
        public List<IStatement> Body { get; } = new List<IStatement>();

        public ForEachLoop(IdentifierAssignment identifier, IExpression expression)
        {
            Identifier = identifier;
            Expression = expression;
        }

        public override string ToString()
        {
            return $"foreach({Identifier} in {Expression}){{{string.Join("", Body)}}}";
        }
    }
}