using CsGenerator.Definition;

namespace CsGenerator.Expression
{
    public class New : IExpression
    {
        public Class C { get; }

        public New(Class c)
        {
            C = c;
        }

        public override string ToString()
        {
            return "new ";
        }
    }
}