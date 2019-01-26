using System.Collections.Generic;
using CsGenerator.Expression;

namespace CsGenerator.Statement.Loop
{
    public class WhileLoop : IStatement
    {
        public IExpression Condition { get; }
        public List<IStatement> Body { get; } = new List<IStatement>();

        public WhileLoop()
        {
        }

        public WhileLoop(IExpression condition)
        {
            Condition = condition;
        }

        public override string ToString()
        {
            return $"while({Condition}){{{string.Join("", Body)}}}";
        }
    }
}