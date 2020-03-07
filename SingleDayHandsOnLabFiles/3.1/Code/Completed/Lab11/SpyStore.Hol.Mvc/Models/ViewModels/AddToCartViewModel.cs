// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Mvc - AddToCartViewModel.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

using System.ComponentModel.DataAnnotations;
using SpyStore.Hol.Models.ViewModels;
using SpyStore.Hol.Mvc.Validation;

namespace SpyStore.Hol.Mvc.Models.ViewModels
{
    public class AddToCartViewModel : CartRecordWithProductInfo
    {
        [Required, MustNotBeGreaterThan(nameof(UnitsInStock)), MustBeGreaterThanZero]
        public new int Quantity { get; set; }
    }
}