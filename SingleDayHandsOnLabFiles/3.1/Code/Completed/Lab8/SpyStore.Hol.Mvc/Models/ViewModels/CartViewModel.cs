// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Mvc - CartViewModel.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

using System.Collections.Generic;
using SpyStore.Hol.Models.Entities;

namespace SpyStore.Hol.Mvc.Models.ViewModels
{
    public class CartViewModel
    {
        public Customer Customer { get; set; }
        public IList<CartRecordViewModel> CartRecords { get; set; }
    }
}