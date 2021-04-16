namespace PizzaBox.Domain.Abstracts
{
    public class Customer
    {
        public string Name { get; protected set; }

         public override string ToString()
        {
            return Name;
        }
    }
}