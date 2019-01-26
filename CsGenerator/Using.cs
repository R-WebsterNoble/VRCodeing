using System;

namespace CsGenerator
{
    public class Using
    {
        public string Resource { get; }

        public Using(string resource)
        {
            if (string.IsNullOrWhiteSpace(resource))
                throw new ArgumentNullException(nameof(resource));

            Resource = resource;
        }

        public override string ToString()
        {
            return $"using {Resource};";
        }
    }
}