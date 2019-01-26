using System.Collections.Generic;
using CsGenerator.Expression;

namespace CsGenerator.Statement
{
    public class ReturnStatement : IStatement
    {
        public List<IExpression> Body { get; } = new List<IExpression>();

        public override string ToString()
        {
            return $"return {string.Join("", Body)};";
        }
    }
}