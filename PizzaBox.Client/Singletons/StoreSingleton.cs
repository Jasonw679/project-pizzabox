using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Singletons
{
  public class StoreSingleton
  {
    public List<AStore> Stores { get; set; }

    private static StoreSingleton _instance;

    public static StoreSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new StoreSingleton();
        }
        return _instance;
      }
    }
    private StoreSingleton()
    {
      Stores = new List<AStore>()
        {
            new JayPizza(),
            new Pizzaria()
        };
    }
  }
}