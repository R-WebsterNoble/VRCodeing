using CsGenerator.Expression;

namespace CsGenerator.Statement
{
    public class FunctionCallStatement : FunctionCallExpression, IStatement
    {
        public FunctionCallStatement(Function function, params IExpression[] parameters) : base(function, parameters)
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()};";
        }
    }
}