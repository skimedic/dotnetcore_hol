#region copyright

// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Models - OrderDetailBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2019/10/04
// See License.txt for more information
// ==================================

#endregion

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpyStore.Hol.Models.Entities.Base
{
    public class OrderDetailBase : EntityBase
    {
        [Required] public int OrderId { get; set; }

        [Required] public int ProductId { get; set; }

        [Required] public int Quantity { get; set; }

        [Required, DataType(DataType.Currency), Display(Name = "Unit Cost")]
        public decimal UnitCost { get; set; }

        [DataType(DataType.Currency), Display(Name = "Total")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal LineItemTotal { get; set; }
    }
}