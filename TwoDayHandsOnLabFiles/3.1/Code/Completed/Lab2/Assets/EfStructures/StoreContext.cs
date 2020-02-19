using Microsoft.EntityFrameworkCore;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.Entities.Base;

namespace SpyStore.Hol.Dal.EfStructures
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}