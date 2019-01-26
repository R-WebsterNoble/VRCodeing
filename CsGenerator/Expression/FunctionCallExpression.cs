using System.Linq;
using CsGenerator.Definition;

namespace CsGenerator.Expression
{
    public class FunctionCallExpression : IExpression
    {
        public Function Function { get; }
        private readonly IExpression[] _parameters;

        public FunctionCallExpression(Function function, params IExpression[] parameters)
        {
            Function = function;
            _parameters = parameters;
        }

        public override string ToString()
        {
            return $"{Function.Name}({string.Join<IExpression>(",", _parameters)})";
        }
    }

    public class ObjectInitialization : IExpression
    {
        public Class Class { get; }
        public ConstructorDefinition ConstructorDefinition { get; }

        public ObjectInitialization(Class @class)
        {
            Class = @class;
        }
        public ObjectInitialization(ConstructorDefinition constructorDefinition)
        {
            ConstructorDefinition = constructorDefinition;
        }

        public override string ToString()
        {
            if (ConstructorDefinition != null)
            return
                $"new {ConstructorDefinition.Constructor.Name}({string.Join(",", ConstructorDefinition.Function.Parameters.Select(p => $"{p.Type} {p.Name}"))})";

            return $"new {Class.Name}()";
        }
    }
}