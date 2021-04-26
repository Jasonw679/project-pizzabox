using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Singletons
{
  public class SizeSingleton
  {
    public List<Size> Sizes { get; set; }

    private static readonly SizeSingleton _instance;

    public static SizeSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          return new SizeSingleton();
        }
        return _instance;
      }
    }
    private SizeSingleton()
    {
      Sizes = new List<Size>()
      {
        new Size("Small", .75f),
        new Size("Medium", 1.0f),
        new Size("Large", 1.25f)
      };
    }
  }
}
