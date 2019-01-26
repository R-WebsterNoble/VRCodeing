namespace CsGenerator.Expression.Operator
{
    public class MemberAccessOperator : Operator
    {
        protected override string Op => ".";

        public MemberAccessOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class NullConditionalOperator : Operator
    {
        protected override string Op => "?.";

        public NullConditionalOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class NullConditionalIndexOperator : Operator
    {
        protected override string Op => "";

        public NullConditionalIndexOperator(IExpression x, IExpression y) : base(x, y)
        {
        }

        public override string ToString()
        {
            return $"{X}?[{Y}]";
        }
    }

    public class FunctionOperator : Operator
    {
        protected override string Op => "";

        public FunctionOperator(IExpression x, IExpression y) : base(x, y)
        {
        }

        public override string ToString()
        {
            return $"{X}({Y})";
        }
    }

    public class IndexingOperator : Operator
    {
        protected override string Op => "";

        public IndexingOperator(IExpression x, IExpression y) : base(x, y)
        {
        }

        public override string ToString()
        {
            return $"{X}[{Y}]";
        }
    }

    public class AdditionOperator : Operator
    {
        protected override string Op => "+";

        public AdditionOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class SubtractionOperator : Operator
    {
        protected override string Op => "-";

        public SubtractionOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class MultiplicationOperator : Operator
    {
        protected override string Op => "*";

        public MultiplicationOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class DivisionOperator : Operator
    {
        protected override string Op => "/";

        public DivisionOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class RemainderOperator : Operator
    {
        protected override string Op => "%";

        public RemainderOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class ShiftLiftOperator : Operator
    {
        protected override string Op => "<<";

        public ShiftLiftOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class ShiftRightOperator : Operator
    {
        protected override string Op => ">>";

        public ShiftRightOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class LessThanOperator : Operator
    {
        protected override string Op => "<";

        public LessThanOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class GreaterThanOperator : Operator
    {
        protected override string Op => ">";

        public GreaterThanOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class LessThanOrEqualToOperator : Operator
    {
        protected override string Op => "<=";

        public LessThanOrEqualToOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class GreaterThanOrEqualToOperator : Operator
    {
        protected override string Op => ">=";

        public GreaterThanOrEqualToOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class IsOperator : Operator
    {
        protected override string Op => " is ";

        public IsOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class AsOperator : Operator
    {
        protected override string Op => " as ";

        public AsOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class EqualsOperator : Operator
    {
        protected override string Op => "==";

        public EqualsOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class NotEqualsOperator : Operator
    {
        protected override string Op => "!=";

        public NotEqualsOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class AndOperator : Operator
    {
        protected override string Op => "&";

        public AndOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class XOROperator : Operator
    {
        protected override string Op => "^";

        public XOROperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class OrOrperator : Operator
    {
        protected override string Op => "|";

        public OrOrperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class ConditionalAndOrperator : Operator
    {
        protected override string Op => "&&";

        public ConditionalAndOrperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class ConditionalOrOrperator : Operator
    {
        protected override string Op => "||";

        public ConditionalOrOrperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class NullCoalescingOrOrperator : Operator
    {
        protected override string Op => "??";

        public NullCoalescingOrOrperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class TurnaryOperator : Operator
    {
        private IExpression Z { get; }
        protected override string Op => "??";

        public TurnaryOperator(IExpression x, IExpression y, IExpression z) : base(x, y)
        {
            Z = z;
        }

        public override string ToString()
        {
            return $"{X}?{Y}:{Z}";
        }
    }

    public class AssignmentOperator : Operator
    {
        protected override string Op => "=";

        public AssignmentOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class IncrementAssignmentOperator : Operator
    {
        protected override string Op => "+=";

        public IncrementAssignmentOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class DecrementAssignmentOperator : Operator
    {
        protected override string Op => "-=";

        public DecrementAssignmentOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class MultiplicationAssignmentOperator : Operator
    {
        protected override string Op => "*=";

        public MultiplicationAssignmentOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class DivisionAssignmentOperator : Operator
    {
        protected override string Op => "/=";

        public DivisionAssignmentOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class RemainderAssignmentOperator : Operator
    {
        protected override string Op => "%=";

        public RemainderAssignmentOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class AndAssignmentOperator : Operator
    {
        protected override string Op => "&=";

        public AndAssignmentOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class OrAssignmentOperator : Operator
    {
        protected override string Op => "*=";

        public OrAssignmentOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class XorAssignmentOperator : Operator
    {
        protected override string Op => "^=";

        public XorAssignmentOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class LeftShiftAssignmentOperator : Operator
    {
        protected override string Op => "<<=";

        public LeftShiftAssignmentOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class RightShiftAssignmentOperator : Operator
    {
        protected override string Op => ">>=";

        public RightShiftAssignmentOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }

    public class LambdaDeclarationOperator : Operator
    {
        protected override string Op => "=>";

        public LambdaDeclarationOperator(IExpression x, IExpression y) : base(x, y)
        {
        }
    }
}