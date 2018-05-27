using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SpyStore_HOL.DAL.EfStructures
{
    public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
    {
        public StoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();

            var connectionString =
                @"Server=(localdb)\mssqllocaldb;Database=SpyStore_HOL2;Trusted_Connection=True;MultipleActiveResultSets=true;";
                optionsBuilder
                   .UseSqlServer(connectionString,options => options.EnableRetryOnFailure())
                   .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            return new StoreContext(optionsBuilder.Options);
        }
    }
}
