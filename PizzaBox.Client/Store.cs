namespace PizzaBox.Client
{
    public class Store
    {
        private string name;
        public Store(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}