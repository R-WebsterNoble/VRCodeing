using System.Collections.Generic;
using CsGenerator.Expression;

namespace CsGenerator.Statement.Loop
{
    public class DoLoop : IStatement
    {
        public IExpression Condition { get; }
        public List<IStatement> Body { get; } = new List<IStatement>();

        public DoLoop()
        {
        }

        public DoLoop(IExpression condition)
        {
            Condition = condition;
        }

        public override string ToString()
        {
            return $"do{{{string.Join("", Body)}}}while({Condition});";
        }
    }
}