using System;
using System.ComponentModel.DataAnnotations;

namespace SpyStore.Hol.Models.Entities.Base
{
    public class ShoppingCartRecordBase : EntityBase
    {
        public DateTime? DateCreated { get; set; }

        public int CustomerId { get; set; }
        public int Quantity { get; set; }

        public decimal LineItemTotal { get; set; }

        public int ProductId { get; set; }
    }
}
