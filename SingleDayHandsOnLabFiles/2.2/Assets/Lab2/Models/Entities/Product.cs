using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using SpyStore.Hol.Models.Entities.Base;

namespace SpyStore.Hol.Models.Entities
{
  public class Product : EntityBase
  {
    public ProductDetails Details { get; set; } = new ProductDetails();
    public bool IsFeatured { get; set; }
	public decimal UnitCost { get; set; }
	public decimal CurrentPrice { get; set; }
    public int UnitsInStock { get; set; }

    public int CategoryId { get; set; }

  }
}