// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Models - ProductDetails.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SpyStore.Hol.Models.Entities.Base
{
    [Owned]
    public class ProductDetails
    {
        [MaxLength(3800)] public string Description { get; set; }
        [MaxLength(50)] public string ModelNumber { get; set; }
        [MaxLength(50)] public string ModelName { get; set; }
        [MaxLength(150)] public string ProductImage { get; set; }
        [MaxLength(150)] public string ProductImageLarge { get; set; }
        [MaxLength(150)] public string ProductImageThumb { get; set; }
    }
}