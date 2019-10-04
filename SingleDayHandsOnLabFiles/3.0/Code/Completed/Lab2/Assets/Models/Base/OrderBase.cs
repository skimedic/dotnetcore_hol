using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpyStore.Hol.Models.Entities.Base
{
    public class OrderBase : EntityBase
    {
        public DateTime OrderDate { get; set; }

        public DateTime ShipDate { get; set; }

        public int CustomerId { get; set; }
    }
}