namespace CsGenerator.Expression.Operator
{
    public abstract class UnaryOperator : IExpression
    {
        protected abstract string Op { get; }
        public IExpression X { get; set; }

        public UnaryOperator(IExpression x)
        {
            X = x;
        }

        public override string ToString()
        {
            return $"{Op}{X}";
        }
    }

    public abstract class Operator : UnaryOperator
    {
        public IExpression Y { get; set; }

        protected Operator(IExpression x, IExpression y) : base(x)
        {
            Y = y;
        }

        public override string ToString()
        {
            return $"{X}{Op}{Y}";
        }
    }
}