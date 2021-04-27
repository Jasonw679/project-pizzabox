using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Singletons;
using PizzaBox.Storing.Repository;
using PizzaBox.Storing;

namespace PizzaBox.Client
{
  public class Program
  {
    private static readonly PizzaBoxContext _context = new PizzaBoxContext();
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance(_context);
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance(_context);
    private static readonly CrustSingleton _crustSingleton = CrustSingleton.Instance;
    private static readonly SizeSingleton _sizeSingleton = SizeSingleton.Instance;
    private static readonly ToppingSingleton _toppingSingleton = ToppingSingleton.Instance;
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance(_context);
    private static readonly OrderRepository _orderRepository = new OrderRepository(_context);
    private static void Main()
    {
      Run();
    }

    private static void Run()
    {
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

      order.Customer = SelectCustomer();
      order.Store = selectStore();

      AddPizza(order);
      viewOrder(order);
    }
    private static Customer SelectCustomer()
    {
      Console.WriteLine("--input your name--");
      var name = Console.ReadLine();
      var c = _customerSingleton.Customers.Find(s => s.Name != null && s.Name.Equals(name));
      if (c == null)
      {
        c = new Customer() { Name = name };
      }
      return c;
    }
    private static AStore selectStore()
    {
      int input;
      bool valid;
      do
      {
        Console.WriteLine("--Choose a store--");
        PrintList(_storeSingleton.Stores);
        valid = int.TryParse(Console.ReadLine(), out input);
      } while (!valid || input > _storeSingleton.Stores.Count || input <= 0);
      return _storeSingleton.Stores[input - 1];
    }
    private static APizza selectPizza()
    {
      int input;
      bool valid;
      do
      {
        Console.WriteLine("--Choose a pizza--");
        PrintList(_pizzaSingleton.Pizzas);
        valid = int.TryParse(Console.ReadLine(), out input);
      } while (!valid || input > _pizzaSingleton.Pizzas.Count || input <= 0);
      return _pizzaSingleton.Pizzas[input - 1];
    }
    private static void AddPizza(Order o)
    {
      int entry;
      bool v;
      do
      {
        Console.WriteLine("0 Present Pizza\n1 Custom Pizza");
        v = int.TryParse(Console.ReadLine(), out entry);
      } while (!v || entry > 1 || entry < 0);
      APizza pizza;
      switch (entry)
      {
        case 0:
          pizza = selectPizza();
          break;
        default:
          int input;
          bool valid;
          do
          {
            Console.WriteLine("--Choose a Crust--");
            PrintList(_crustSingleton.Crusts);
            valid = int.TryParse(Console.ReadLine(), out input);
          } while (!valid || input > _crustSingleton.Crusts.Count || input <= 0);
          var crust = _crustSingleton.Crusts[input - 1];
          List<Topping> toppings = new List<Topping>();
          AddToppings(toppings);
          pizza = new CustomPizza(crust, toppings);
          break;
      }
      pizza.Size = SelectSize();
      o.pizzas.Add(pizza);
    }
    private static void RemovePizza(Order o)
    {
      int input;
      do
      {
        Console.WriteLine("Which Pizza to Remove");
        o.PrintOrderedPizzas();
      } while (!int.TryParse(Console.ReadLine(), out input) && input < o.pizzas.Count);
      o.pizzas.RemoveAt(input);
    }
    private static void AddTopping(List<Topping> toppings)
    {
      int input;
      bool valid;
      do
      {
        Console.WriteLine("--Choose a topping--");
        PrintList(_toppingSingleton.Toppings);
        valid = int.TryParse(Console.ReadLine(), out input);
      } while (!valid || input > _toppingSingleton.Toppings.Count || input <= 0);
      toppings.Add(_toppingSingleton.Toppings[input - 1]);
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
      } while (!input.Equals("N") || o.pizzas.Count >= 50);
      CheckoutOrder(o);
    }
    public static Size SelectSize()
    {
      int input;
      bool valid;
      do
      {
        Console.WriteLine("--Choose a Size--");
        PrintList(_sizeSingleton.Sizes);
        valid = int.TryParse(Console.ReadLine(), out input);
      } while (!valid || input > _sizeSingleton.Sizes.Count || input <= 0);
      return _sizeSingleton.Sizes[input - 1];
    }
    private static void CheckoutOrder(Order o)
    {
      Console.WriteLine($"Checkout your order\n {o}");
      o.Customer.orders.Add(o);
      _orderRepository.Save(o);
    }
    private static void PrintList(IEnumerable<object> list)
    {
      var i = 0;
      foreach (var v in list)
      {
        Console.WriteLine($"{++i} {v}");
      }
    }
  }
}