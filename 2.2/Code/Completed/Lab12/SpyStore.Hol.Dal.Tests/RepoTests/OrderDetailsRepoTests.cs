using System;
using System.Linq;
using SpyStore.Hol.Dal.Initialization;
using SpyStore.Hol.Dal.Repos;
using Xunit;

namespace SpyStore.Hol.Dal.Tests.RepoTests
{
    [Collection("SpyStore.DAL")]
    public class OrderDetailRepoTests : IDisposable
    {
        private readonly OrderDetailRepo _repo;

        public OrderDetailRepoTests()
        {
            _repo = new OrderDetailRepo();
            SampleDataInitializer.InitializeData(_repo.Context);

        }
        public void Dispose()
        {
            SampleDataInitializer.ClearData(_repo.Context);
            _repo.Dispose();
        }

        [Fact]
        public void ShouldGetAllOrderDetails()
        {
            var orders = _repo.GetAll().ToList();
            Assert.Equal(_repo.Count,orders.Count());
        }

        [Fact]
        public void ShouldGetLineItemTotal()
        {
            var orderDetails = _repo.GetAll().ToList();
            var orderDetail = orderDetails[0];
            Assert.Equal(1799.9700M, orderDetail.LineItemTotal);
        }

    }
}
