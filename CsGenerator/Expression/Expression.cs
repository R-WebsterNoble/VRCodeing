using CsGenerator.Statement;

namespace CsGenerator.Expression
{
    public class Expression : IExpression, IStatement
    {
        public object O { get; set; }

        public Expression(object o)
        {
            O = o;
        }

        public override string ToString()
        {
            return O.ToString();
        }
    }
}