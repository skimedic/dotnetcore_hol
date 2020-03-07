// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal - IOrderRepo.cs
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
    public interface IOrderRepo : IRepo<Order>
    {
        OrderWithDetailsAndProductInfo GetOneWithDetails(int orderId);
        IList<Order> GetOrderHistory();
    }
}