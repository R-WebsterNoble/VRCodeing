using System;

namespace CsGenerator.Definition
{
    public class ParameterDefinition
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public ParameterDefinition(string name, string type)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentNullException(nameof(type));

            Name = name;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Type} {Name}";
        }
    }
}