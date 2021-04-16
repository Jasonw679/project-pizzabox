using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Order
    {
        public AStore store;
        public List<APizza> pizzas = new List<APizza>();
        public Customer customer;
        public override string ToString()
        {
            string result = "";
            for(int i = 0; i < pizzas.Count; i+=1)
            {
                if(i > 0){
                    result += ", ";
                }
                if(i == pizzas.Count - 1 && pizzas.Count > 1)
                {
                    result += "and ";
                }
                result += pizzas[i];
            }
            return $"{result} order in {store}";
        }
    }
}