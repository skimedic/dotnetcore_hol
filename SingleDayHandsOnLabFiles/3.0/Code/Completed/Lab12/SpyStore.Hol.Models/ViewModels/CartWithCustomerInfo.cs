#region copyright

// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Models - CartWithCustomerInfo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2019/10/04
// See License.txt for more information
// ==================================

#endregion

using System.Collections.Generic;
using SpyStore.Hol.Models.Entities;

namespace SpyStore.Hol.Models.ViewModels
{
    public class CartWithCustomerInfo
    {
        public Customer Customer { get; set; }

        public IList<CartRecordWithProductInfo> CartRecords { get; set; }
            = new List<CartRecordWithProductInfo>();
    }
}