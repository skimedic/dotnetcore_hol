using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Dal.Repos.Base;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Models.Entities;

namespace SpyStore.Hol.Dal.Repos
{
    public class ProductRepo : RepoBase<Product>,IProductRepo
    {
        public ProductRepo(StoreContext context) : base(context)
        {
        }

        internal ProductRepo(DbContextOptions<StoreContext> options) : base(options)
        {
        }
    }
}
