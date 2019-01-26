using System;
using System.Collections.Generic;

namespace CsGenerator.Definition
{
    public class Class : INamespacedItem
    {
        public string Name { get; }
        public List<IClassItem> Body { get; } = new List<IClassItem>();

        public Class(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        public override string ToString()
        {
            return $"public class {Name}{{{string.Join("", Body)}}}";
        }
    }
}