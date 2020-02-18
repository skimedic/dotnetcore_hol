#region copyright

// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal - IShoppingCartRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2019/10/04
// See License.txt for more information
// ==================================

#endregion

using System;
using System.Collections.Generic;
using SpyStore.Hol.Dal.Repos.Base;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.ViewModels;

namespace SpyStore.Hol.Dal.Repos.Interfaces
{
    public interface IShoppingCartRepo : IRepo<ShoppingCartRecord>
    {
        CartRecordWithProductInfo GetShoppingCartRecord(int id);
        IEnumerable<CartRecordWithProductInfo> GetShoppingCartRecords(int customerId);
        CartWithCustomerInfo GetShoppingCartRecordsWithCustomer(int customerId);
        ShoppingCartRecord GetBy(int productId);
        int Update(ShoppingCartRecord entity, Product product, bool persist = true);
        int Add(ShoppingCartRecord entity, Product product, bool persist = true);
        int Purchase(int customerId);
    }
}