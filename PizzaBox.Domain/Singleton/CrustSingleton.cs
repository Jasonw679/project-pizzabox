using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Singletons
{
  public class CrustSingleton
  {
    public Crust Thin = new Crust("Thin", 0.75f);
    public Crust Medium = new Crust("Medium", 1.0f);
    public Crust Thick = new Crust("Thick", 1.25f);
    public List<Crust> Crusts { get; set; }
    private static readonly CrustSingleton _instance;
    public static CrustSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          return new CrustSingleton();
        }
        return _instance;
      }
    }
    private CrustSingleton()
    {

      Crusts = new List<Crust>()
      {
        Thin,
        Medium,
        Thick
      };
    }
  }
}
