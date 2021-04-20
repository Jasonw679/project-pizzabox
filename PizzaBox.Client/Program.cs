using System.Collections.Generic;
using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;

namespace PizzaBox.Client
{
  public class Program
  {
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;
    private static readonly CrustSingleton _crustSigleton = CrustSingleton.Instance;
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
    private static void PrintCrustList()
    {
      for (var i = 1; i < _crustSigleton.Crusts.Count; i++)
      {
        System.Console.WriteLine($"{i} {_crustSigleton.Crusts[i]}");
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
      switch (entry)
      {
        case 1:
          PrintPizzaList();
          o.pizzas.Add(selectPizza());
          break;
        case 2:

          o.pizzas.Add(new CustomPizza());
          break;
      }
    }
    private static void RemovePizza(Order o)
    {
      Console.WriteLine("Which Pizza to Remove");
      o.PrintOrderedPizzas();
      var entry = int.Parse(Console.ReadLine());
      o.pizzas.RemoveAt(entry);
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
    private static void CheckoutOrder(Order o)
    {
      Console.WriteLine($"Checkout your order\n {o}");
      o.customer.orders.Add(o);
    }
  }
}