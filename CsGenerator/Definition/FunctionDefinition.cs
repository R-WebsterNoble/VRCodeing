using System.Collections.Generic;
using System.Linq;
using CsGenerator.Statement;

namespace CsGenerator.Definition
{
    public class FunctionDefinition : IClassItem
    {
        public Function Function { get; }
        public List<IStatement> Body { get; } = new List<IStatement>();

        public FunctionDefinition(Function function)
        {
            Function = function;
        }

        public override string ToString()
        {
            var parameters = string.Join(",", Function.Parameters.Select(p => $"{p.Type} {p.Name}"));
            var body = string.Join(" ", Body);
            return $"public {Function.ReturnType} {Function.Name}({parameters}){{{body}}}";
        }
    }

    public class ConstructorDefinition : FunctionDefinition
    {
        public Constructor Constructor { get; }

        public ConstructorDefinition(Constructor constructor) : base(constructor)
        {
            Constructor = constructor;
        }
    }
}