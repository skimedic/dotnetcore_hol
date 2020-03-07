// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal - IShoppingCartRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using SpyStore.Hol.Dal.Repos.Base;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.ViewModels;

namespace SpyStore.Hol.Dal.Repos.Interfaces
{
    public interface IShoppingCartRepo : IRepo<ShoppingCartRecord>
    {
        int Add(ShoppingCartRecord entity, Product product, bool persist = true);
        ShoppingCartRecord GetBy(int productId);
        CartRecordWithProductInfo GetShoppingCartRecord(int id);
        IEnumerable<CartRecordWithProductInfo> GetShoppingCartRecords(int customerId);
        CartWithCustomerInfo GetShoppingCartRecordsWithCustomer(int customerId);
        int Purchase(int customerId);
        int Update(ShoppingCartRecord entity, Product product, bool persist = true);
    }
}