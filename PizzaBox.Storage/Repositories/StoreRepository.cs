using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storage.Repositories
{
  public class StoreRepository : IRepository<AStore>
  {
    private readonly PizzaBoxContext _context;

    public StoreRepository(PizzaBoxContext context)
    {
      _context = context;
    }

    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(AStore entry)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<AStore> Select(Func<AStore, bool> filter)
    {
      return _context.Stores.Where(filter);
    }

    public AStore Update()
    {
      throw new System.NotImplementedException();
    }
  }
}