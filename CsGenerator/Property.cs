using System;

namespace CsGenerator
{
    public class Property : IClassItem
    {
        public string Type { get; }
        public string Name { get; }

        public Property(string type, string name)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentNullException(nameof(name));

            Type = type;
            Name = name;
        }

        public override string ToString()
        {
            return $"public {Type} {Name} {{get;}}";
        }
    }
}