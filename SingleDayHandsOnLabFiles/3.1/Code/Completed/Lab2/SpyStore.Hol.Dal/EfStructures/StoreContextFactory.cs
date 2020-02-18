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
      var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
      var connectionString =
        @"Server=.,6433;Database=SpyStoreHol;User ID=sa;Password=P@ssw0rd;MultipleActiveResultSets=true;";
      optionsBuilder
        .UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
      Console.WriteLine(connectionString);
      return new StoreContext(optionsBuilder.Options);
    }
  }
}