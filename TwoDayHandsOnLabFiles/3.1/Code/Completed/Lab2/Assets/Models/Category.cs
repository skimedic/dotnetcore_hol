using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpyStore.Hol.Models.Entities.Base;

namespace SpyStore.Hol.Models.Entities
{
  public class Category : EntityBase
  {
    public string CategoryName { get; set; }

  }
}