#region copyright

// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Models - Category.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2019/10/04
// See License.txt for more information
// ==================================

#endregion

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpyStore.Hol.Models.Entities.Base;

namespace SpyStore.Hol.Models.Entities
{
    [Table("Categories", Schema = "Store")]
    public class Category : EntityBase
    {
        [DataType(DataType.Text), MaxLength(50)]
        public string CategoryName { get; set; }

        [InverseProperty(nameof(Product.CategoryNavigation))]
        public List<Product> Products { get; set; } = new List<Product>();
    }
}