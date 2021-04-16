using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    [XmlInclude(typeof(Pizzaria))]
    [XmlInclude(typeof(JayPizza))]
    public abstract class AStore
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}