// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Models - OrderDetail.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

using System.ComponentModel.DataAnnotations.Schema;
using SpyStore.Hol.Models.Entities.Base;

namespace SpyStore.Hol.Models.Entities
{
    [Table("OrderDetails", Schema = "Store")]
    public class OrderDetail : OrderDetailBase
    {
        [ForeignKey(nameof(OrderId))] public Order OrderNavigation { get; set; }

        [ForeignKey(nameof(ProductId))] public Product ProductNavigation { get; set; }
    }
}