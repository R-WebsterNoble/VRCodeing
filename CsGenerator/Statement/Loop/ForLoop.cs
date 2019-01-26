using System.Collections.Generic;
using CsGenerator.Expression;

namespace CsGenerator.Statement.Loop
{
    public class ForLoop : IStatement
    {
        public IExpression Initializer { get; }
        public IExpression Condition { get; }
        public IExpression Iterator { get; }

        public List<IStatement> Body { get; } = new List<IStatement>();

        public ForLoop(IExpression initializer, IExpression condition, IExpression iterator)
        {
            Initializer = initializer;
            Condition = condition;
            Iterator = iterator;
        }

        public override string ToString()
        {
            return $"for({Initializer};{Condition};{Iterator}){{{string.Join("", Body)}}}";
        }
    }
}