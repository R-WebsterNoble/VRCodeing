using System;
using CsGenerator.Expression;

namespace CsGenerator
{
    public class Identifier : IExpression
    {
        public string Type { get; }
        public string Name { get; set; }
        public IExpression O { get; }

        public Identifier(string type, string name, IExpression o)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentNullException(nameof(type));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Type = type;
            Name = name;
            O = o;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}