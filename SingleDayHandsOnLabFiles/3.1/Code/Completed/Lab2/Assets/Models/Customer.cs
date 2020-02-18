using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SpyStore.Hol.Models.Entities.Base;

namespace SpyStore.Hol.Models.Entities
{
  public class Customer : EntityBase
  {
    public string FullName { get; set; }

    public string EmailAddress { get; set; }

    public string Password { get; set; }


  }
}