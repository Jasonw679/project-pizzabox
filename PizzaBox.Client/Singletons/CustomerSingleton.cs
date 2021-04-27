using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Singletons
{
  public class CustomerSingleton
  {
    public List<Customer> Customers { get; set; }
    private static readonly CustomerSingleton _instance;
    public static CustomerSingleton Instance(PizzaBoxContext context)
    {
      if (_instance == null)
      {
        return new CustomerSingleton(context);
      }
      return _instance;
    }
    private CustomerSingleton(PizzaBoxContext context)
    {
      Customers = context.Customers.ToList();
      if (Customers.Count == 0)
      {
        Customers = new List<Customer>();
      }
    }
  }
}