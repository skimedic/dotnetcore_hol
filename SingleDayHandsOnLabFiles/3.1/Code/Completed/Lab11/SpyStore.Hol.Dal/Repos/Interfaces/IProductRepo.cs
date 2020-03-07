// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal - IProductRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using SpyStore.Hol.Dal.Repos.Base;
using SpyStore.Hol.Models.Entities;

namespace SpyStore.Hol.Dal.Repos.Interfaces
{
    public interface IProductRepo : IRepo<Product>
    {
        IList<Product> GetFeaturedWithCategoryName();
        Product GetOneWithCategoryName(int id);
        IList<Product> GetProductsForCategory(int id);
        IList<Product> Search(string searchString);
    }
}