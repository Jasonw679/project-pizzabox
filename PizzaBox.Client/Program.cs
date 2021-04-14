using System.Collections.Generic;
using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
    public class Program
    {
        private static void Main()
        {
            var stores = new List<AStore>{ new JayPizza(), new Pizzaria()};
            Console.WriteLine("--Stores--");
            for(var x = 0; x < stores.Count; x += 1)
            {
                Console.WriteLine($"{x} {stores[x]}");
            }

            Console.WriteLine("--Choose a store--");
            var input = Console.ReadLine();
            int entry = int.Parse(input);

            Console.WriteLine(stores[entry]);
        }
    }
}