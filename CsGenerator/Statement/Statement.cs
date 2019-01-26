using CsGenerator.Expression;

namespace CsGenerator.Statement
{
    public class Statement : IStatement
    {
        public IExpression Expression { get; }

        public Statement(IExpression expression)
        {
            Expression = expression;
        }

        public override string ToString()
        {
            return $"{Expression};";
        }
    }
}