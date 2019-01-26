namespace CsGenerator.Expression.Operator
{
    public class PlusUnaryOperator : UnaryOperator
    {
        protected override string Op => "+";

        public PlusUnaryOperator(IExpression x) : base(x)
        {
        }
    }

    public class NumericNegationUnaryOperator : UnaryOperator
    {
        protected override string Op => "-";

        public NumericNegationUnaryOperator(IExpression x) : base(x)
        {
        }
    }

    public class LogicalNegationUnaryOperator : UnaryOperator
    {
        protected override string Op => "!";

        public LogicalNegationUnaryOperator(IExpression x) : base(x)
        {
        }
    }

    public class BitwiseComplementUnaryOperator : UnaryOperator
    {
        protected override string Op => "~";

        public BitwiseComplementUnaryOperator(IExpression x) : base(x)
        {
        }
    }

    public class PrefixIncrementUnaryOperator : UnaryOperator
    {
        protected override string Op => "++";

        public PrefixIncrementUnaryOperator(IExpression x) : base(x)
        {
        }
    }

    public class PrefixDecrementUnaryOperator : UnaryOperator
    {
        protected override string Op => "--";

        public PrefixDecrementUnaryOperator(IExpression x) : base(x)
        {
        }
    }

    public class PostfixIncrementUnaryOperator : UnaryOperator
    {
        protected override string Op => "++";

        public PostfixIncrementUnaryOperator(IExpression x) : base(x)
        {
        }

        public override string ToString()
        {
            return $"{X}++";
        }
    }

    public class PostfixDecrementUnaryOperator : UnaryOperator
    {
        protected override string Op => "--";

        public PostfixDecrementUnaryOperator(IExpression x) : base(x)
        {
        }

        public override string ToString()
        {
            return $"{X}--";
        }
    }

    public class AwaitUnaryOperator : UnaryOperator
    {
        protected override string Op => "await ";

        public AwaitUnaryOperator(IExpression x) : base(x)
        {
        }
    }

    public class TypeofOperator : UnaryOperator
    {
        protected override string Op => "";

        public TypeofOperator(IExpression x) : base(x)
        {
        }

        public override string ToString()
        {
            return $"typeof({X})";
        }
    }

    public class SizeofOperator : UnaryOperator
    {
        protected override string Op => "";

        public SizeofOperator(IExpression x) : base(x)
        {
        }

        public override string ToString()
        {
            return $"sizeof({X})";
        }
    }

    public class CheckedOperator : UnaryOperator
    {
        protected override string Op => "";

        public CheckedOperator(IExpression x) : base(x)
        {
        }

        public override string ToString()
        {
            return $"checked({X})";
        }
    }

    public class UncheckedOperator : UnaryOperator
    {
        protected override string Op => "";

        public UncheckedOperator(IExpression x) : base(x)
        {
        }

        public override string ToString()
        {
            return $"unchecked({X})";
        }
    }

    public class DefaultOperator : UnaryOperator
    {
        protected override string Op => "";

        public DefaultOperator(IExpression x) : base(x)
        {
        }

        public override string ToString()
        {
            return $"default({X})";
        }
    }
}