using System;
using System.Collections.Generic;

namespace CsGenerator
{
    public class Namespace
    {
        public string Name { get; set; }
        public List<Using> Usings { get; } = new List<Using>();
        public List<INamespacedItem> NamespacedItems { get; set; } = new List<INamespacedItem>();

        public Namespace(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        public override string ToString()
        {
            return $"{string.Join("", Usings)}namespace {Name}{{{string.Join("", NamespacedItems)}}}";
        }
    }
}