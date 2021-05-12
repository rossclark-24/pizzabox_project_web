using System;
using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storage.Repositories
{
  public class PizzaRepository : IRepository<Pizza>
  {
    private readonly PizzaBoxContext _context;

    public PizzaRepository(PizzaBoxContext context)
    {
      _context = context;
    }

    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(Pizza entry)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<Pizza> Select(Func<Pizza, bool> filter)
    {
      throw new System.NotImplementedException();
    }

    public Pizza Update()
    {
      throw new System.NotImplementedException();
    }
  }
}
