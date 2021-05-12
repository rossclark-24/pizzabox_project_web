using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storage.Repositories
{
  public class ToppingRepository : IRepository<Topping>
  {
    private readonly PizzaBoxContext _context;

    public delegate bool ToppingDelegate(Topping topping);

    public ToppingRepository(PizzaBoxContext context)
    {
      _context = context;
    }

    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(Topping entry)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<Topping> Select(Func<Topping, bool> filter)
    {
      return _context.Toppings.Where(filter);
    }

    public Topping Update()
    {
      throw new System.NotImplementedException();
    }
  }
}
