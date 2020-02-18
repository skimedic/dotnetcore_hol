using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpyStore.Hol.Models.Entities.Base
{
    public class OrderDetailBase : EntityBase
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitCost { get; set; }

    }
}
