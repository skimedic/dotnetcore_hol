using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SpyStore.Hol.Dal.EfStructures
{
  public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
  {
    public StoreContext CreateDbContext(string[] args)
    {
    }
  }
}