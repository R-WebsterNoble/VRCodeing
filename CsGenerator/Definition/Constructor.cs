namespace CsGenerator.Definition
{
    public class Constructor : Function
    {
        public Constructor(Class @class, params Identifier[] parameters) : base("void", @class.Name, parameters)
        {
        }
    }
}