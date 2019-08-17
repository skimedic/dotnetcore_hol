using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Dal.Repos.Base;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.ViewModels;

namespace SpyStore.Hol.Dal.Repos
{
    public class OrderRepo : RepoBase<Order>,IOrderRepo
    {
        public OrderRepo(
            StoreContext context) : base(context)
        {
        }
        internal OrderRepo(DbContextOptions<StoreContext> options) : base(options)
        {
        }
    }
}
