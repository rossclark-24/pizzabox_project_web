using System.Collections.Generic;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Stores;

namespace PizzaBox.Domain.Abstracts
{
  [XmlInclude(typeof(ChicagoStore))]
  [XmlInclude(typeof(NewYorkStore))]
  public abstract class AStore : Entity
  {
    public string Name { get; set; }
    public List<Order> Orders { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}