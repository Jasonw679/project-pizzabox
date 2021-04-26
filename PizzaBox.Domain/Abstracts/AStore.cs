namespace PizzaBox.Domain.Abstracts
{
  public abstract class AStore : AModel
  {
    public string Name { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}