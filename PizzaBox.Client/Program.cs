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
      string input;
      do
      {
        input = Console.ReadLine();
      }
      while (input.Equals("Y") || input.Equals("N"));
    }
    private static void placeOrder()
    {
      var order = new Order();
      printStoreList();

      order.customer = new Customer();
      order.store = selectStore();

      Console.WriteLine("0 Preset Pizza\n 1 Custom Pizza");
      var entry = int.Parse(Console.ReadLine());

      switch (entry)
      {
        case 0:
          PrintPizzaList();
          order.pizzas.Add(selectPizza());
          break;
        case 1:
          order.pizzas.Add(new CustomPizza());
          break;
      }
      viewOrder(order);
      Console.WriteLine("Do you want to modify your order Y/N");
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
      int entry = int.Parse(Console.ReadLine());
      return _pizzaSingleton.Pizzas[entry];
    }
    private static void viewOrder(Order o)
    {
      Console.WriteLine($"Review your order\n {o}");
    }
  }
}