namespace PizzaBox.Domain.Abstracts
{
  public abstract class APizza
  {
    protected string Name;
    protected string crust;
    protected int size;
    protected string[] toppings;
    protected float price;
    public APizza()
    {
      AddCrust();
      AddSize();
      AddToppings();
    }
    protected virtual void AddCrust()
    {

    }
    protected virtual void AddSize()
    {

    }
    protected virtual void AddToppings()
    {

    }
    public override string ToString()
    {
      return Name;
    }
  }
}