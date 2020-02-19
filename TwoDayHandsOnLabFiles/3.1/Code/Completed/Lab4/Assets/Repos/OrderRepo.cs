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
        private bool _isDisposed;
        public OrderRepo(
            StoreContext context) : base(context)
        {
        }
        internal OrderRepo(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        protected override void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            } 
      
            if (disposing) {
            }
      
            _isDisposed = true;
            // Call base class implementation.
            base.Dispose(disposing);
        }
    }
}
