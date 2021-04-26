using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Singletons;

namespace PizzaBox.Client
{
  public class Program
  {
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;
    private static readonly CrustSingleton _crustSingleton = CrustSingleton.Instance;
    private static readonly SizeSingleton _sizeSingleton = SizeSingleton.Instance;
    private static readonly ToppingSingleton _toppingSingleton = ToppingSingleton.Instance;
    private static void Main()
    {
      Run();
    }

    private static void Run()
    {
      var ss = StoreSingleton.Instance;
      var ps = PizzaSingleton.Instance;
      Console.WriteLine("Welcome to Pizza Box");
      placeOrder();
      var input = "";
      do
      {
        Console.WriteLine("Would you like to make a new order?");
        input = Console.ReadLine();
        if (input.Equals("Y"))
        {
          placeOrder();
        }
      } while (input.Equals("N"));
    }
    private static void placeOrder()
    {
      var order = new Order();
      printStoreList();

      order.customer = new Customer();
      order.store = selectStore();

      PrintPizzaList();
      order.pizzas.Add(selectPizza());
      viewOrder(order);
    }
    private static void printStoreList()
    {
      Console.WriteLine("--Stores--");
      for (var x = 0; x < _storeSingleton.Stores.Count; x += 1)
      {
        Console.WriteLine($"{x} {_storeSingleton.Stores[x]}");
      }
    }
    private static AStore selectStore()
    {
      Console.WriteLine("--Choose a store--");
      int entry = int.Parse(Console.ReadLine());
      return _storeSingleton.Stores[entry];
    }
    private static void PrintPizzaList()
    {
      Console.WriteLine("--Pizzas--");
      for (var x = 0; x < _pizzaSingleton.Pizzas.Count; x += 1)
      {
        Console.WriteLine($"{x} {_pizzaSingleton.Pizzas[x]}");
      }
    }
    private static APizza selectPizza()
    {
      Console.WriteLine("--Choose a pizza--");
      var entry = int.Parse(Console.ReadLine());
      return _pizzaSingleton.Pizzas[entry];
    }
    private static void AddPizza(Order o)
    {
      Console.WriteLine("0 Present Pizza\n1 Custom Pizza");
      var entry = int.Parse(Console.ReadLine());
      APizza pizza;
      switch (entry)
      {
        case 0:
          PrintPizzaList();
          pizza = selectPizza();
          break;
        default:
          Console.WriteLine("Choose a Crust");
          PrintCrustList();
          var crust = _crustSingleton.Crusts[int.Parse(Console.ReadLine())];
          List<Topping> toppings = new List<Topping>();
          AddToppings(toppings);
          pizza = new CustomPizza(crust, toppings);
          break;
      }
      Console.WriteLine("--Choose a Size--");
      PrintSizeList();
      pizza.Size = SelectSize();
      o.pizzas.Add(pizza);
    }
    private static void RemovePizza(Order o)
    {
      Console.WriteLine("Which Pizza to Remove");
      o.PrintOrderedPizzas();
      var entry = int.Parse(Console.ReadLine());
      o.pizzas.RemoveAt(entry);
    }
    public static void PrintCrustList()
    {
      for (int i = 1; i < _crustSingleton.Crusts.Count; i++)
      {
        System.Console.WriteLine($"{i} {_crustSingleton.Crusts[i]}");
      }
    }
    private static void AddTopping(List<Topping> toppings)
    {
      Console.WriteLine("Add a topping");
      PrintToppingList();
      toppings.Add(toppings[int.Parse(Console.ReadLine())]);
    }
    protected static void AddToppings(List<Topping> toppings)
    {
      for (int i = 0; i < 2; i++)
      {
        AddTopping(toppings);
      }
      var input = "";
      do
      {
        Console.WriteLine("Add another topping? Y/N");
        input = Console.ReadLine();
        if (input.Equals("Y"))
        {
          AddTopping(toppings);
        }
      } while (input.Equals("N") || toppings.Count > 4);
    }
    public static void PrintToppingList()
    {
      for (int i = 1; i < _toppingSingleton.Toppings.Count; i++)
      {
        System.Console.WriteLine($"{i} {_toppingSingleton.Toppings[i]}");
      }
    }
    private static void viewOrder(Order o)
    {
      Console.WriteLine($"Review your order\n {o}");
      var input = "";
      do
      {
        Console.WriteLine("Do you want to add another pizza Y/N");
        input = Console.ReadLine();
        if (input.Equals("Y"))
        {
          Console.WriteLine("Do you want to 'add' or 'remove pizza'");
          var input2 = Console.ReadLine();
          switch (input2)
          {
            case "add":
              AddPizza(o);
              break;
            case "remove":
              RemovePizza(o);
              break;
          }
        }
      } while (input.Equals("N") || o.pizzas.Count >= 50);
      CheckoutOrder(o);
    }
    public static void PrintSizeList()
    {
      for (int i = 1; i < _sizeSingleton.Sizes.Count; i++)
      {
        System.Console.WriteLine($"{i} {_sizeSingleton.Sizes[i]}");
      }
    }
    public static Size SelectSize()
    {
      var entry = int.Parse(Console.ReadLine());
      return _sizeSingleton.Sizes[entry];
    }
    private static void CheckoutOrder(Order o)
    {
      Console.WriteLine($"Checkout your order\n {o}");
      o.customer.orders.Add(o);
    }
  }
}