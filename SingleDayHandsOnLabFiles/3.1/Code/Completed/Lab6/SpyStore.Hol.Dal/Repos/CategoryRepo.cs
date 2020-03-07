// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal - CategoryRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Dal.Repos.Base;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Models.Entities;

namespace SpyStore.Hol.Dal.Repos
{
    public class CategoryRepo : RepoBase<Category>, ICategoryRepo
    {
        public CategoryRepo(StoreContext context) : base(context)
        {
        }

        internal CategoryRepo(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public override IEnumerable<Category> GetAll() => base.GetAll(x => x.CategoryName);
    }
}