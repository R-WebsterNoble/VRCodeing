using System.Collections.Generic;
using CsGenerator.Expression;

namespace CsGenerator.Statement
{
    public class If : IStatement
    {
        public IExpression Condition { get; }
        public List<IStatement> Body { get; } = new List<IStatement>();

        public If(IExpression condition)
        {
            Condition = condition;
        }

        public override string ToString()
        {
            return $"if({Condition}){{{string.Join("", Body)}}}";
        }
    }
}