using System;

namespace CsGenerator
{
    public class Function
    {
        public string ReturnType { get; }
        public string Name { get; }
        public Identifier[] Parameters { get; }

        public Function(string returnType, string name, params Identifier[] parameters)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(returnType));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Parameters = parameters;
            ReturnType = returnType;
            Name = name;
        }
    }
}