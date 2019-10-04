#region copyright

// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Models - ShoppingCartRecord.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2019/10/04
// See License.txt for more information
// ==================================

#endregion

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SpyStore.Hol.Models.Entities.Base;

namespace SpyStore.Hol.Models.Entities
{
    [Table("ShoppingCartRecords", Schema = "Store")]
    public class ShoppingCartRecord : ShoppingCartRecordBase
    {
        [JsonIgnore]
        [ForeignKey(nameof(CustomerId))]
        public Customer CustomerNavigation { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(ProductId))]
        public Product ProductNavigation { get; set; }
    }
}