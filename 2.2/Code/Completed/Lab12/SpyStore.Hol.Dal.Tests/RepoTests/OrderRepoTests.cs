using System;
using System.Linq;
using SpyStore.Hol.Dal.Initialization;
using SpyStore.Hol.Dal.Repos;
using Xunit;

namespace SpyStore.Hol.Dal.Tests.RepoTests
{
    [Collection("SpyStore.DAL")]
    public class OrderRepoTests : IDisposable
    {
        private readonly OrderRepo _repo;

        public OrderRepoTests()
        {
            _repo = new OrderRepo(new OrderDetailRepo());
            SampleDataInitializer.InitializeData(_repo.Context);

        }
        public void Dispose()
        {
            SampleDataInitializer.ClearData(_repo.Context);
            _repo.Dispose();
        }

        [Fact]
        public void ShouldGetAllOrders()
        {
            var orders = _repo.GetAll().ToList();
            Assert.Single(orders);
        }
    }
}
