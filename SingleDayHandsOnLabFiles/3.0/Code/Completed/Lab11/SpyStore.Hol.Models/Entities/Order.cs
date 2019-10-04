#region copyright

// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Models - Order.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2019/10/04
// See License.txt for more information
// ==================================

#endregion

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SpyStore.Hol.Models.Entities.Base;

namespace SpyStore.Hol.Models.Entities
{
    [Table("Orders", Schema = "Store")]
    public class Order : OrderBase
    {
        [ForeignKey(nameof(CustomerId))] public Customer CustomerNavigation { get; set; }

        [InverseProperty(nameof(OrderDetail.OrderNavigation))]
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}