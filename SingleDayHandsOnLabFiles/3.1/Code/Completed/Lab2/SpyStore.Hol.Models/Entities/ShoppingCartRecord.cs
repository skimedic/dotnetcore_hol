// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Models - ShoppingCartRecord.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SpyStore.Hol.Models.Entities.Base;

namespace SpyStore.Hol.Models.Entities
{
    [Table("ShoppingCartRecords", Schema = "Store")]
    public class ShoppingCartRecord : ShoppingCartRecordBase
    {
        [ForeignKey(nameof(CustomerId))] public Customer CustomerNavigation { get; set; }

        [ForeignKey(nameof(ProductId))] public Product ProductNavigation { get; set; }
    }
}