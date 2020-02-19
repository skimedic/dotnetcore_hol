using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Dal.Exceptions;
using SpyStore.Hol.Dal.Repos.Base;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.ViewModels;

namespace SpyStore.Hol.Dal.Repos
{
    public class ShoppingCartRepo : RepoBase<ShoppingCartRecord>, IShoppingCartRepo
    {
        private bool _isDisposed;
        public ShoppingCartRepo(StoreContext context) : base(context)
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
        internal ShoppingCartRepo(DbContextOptions<StoreContext> options): base(new StoreContext(options))
        {
        }

    }
}
