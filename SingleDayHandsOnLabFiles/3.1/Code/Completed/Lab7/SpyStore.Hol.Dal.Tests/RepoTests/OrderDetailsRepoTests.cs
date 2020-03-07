// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal.Tests - OrderDetailsRepoTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

using System;
using System.Linq;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Dal.Initialization;
using SpyStore.Hol.Dal.Repos;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Dal.Tests.RepoTests.Base;
using Xunit;

namespace SpyStore.Hol.Dal.Tests.RepoTests
{
    [Collection("SpyStore.DAL")]
    public class OrderDetailRepoTests : RepoTestsBase
    {
        public OrderDetailRepoTests()
        {
            _repo = new OrderDetailRepo(Db);
            Db.CustomerId = 1;
            LoadDatabase();
        }

        private readonly IOrderDetailRepo _repo;

        public override void Dispose()
        {
            _repo.Dispose();
        }

        [Fact]
        public void ShouldGetAllOrderDetails()
        {
            var orders = _repo.GetAll().ToList();
            Assert.Equal(_repo.Table.Count(), orders.Count());
        }

        [Fact]
        public void ShouldGetLineItemTotal()
        {
            var orderDetails = _repo.GetAll().ToList();
            var orderDetail = orderDetails.FirstOrDefault(x => x.ProductId == 25);
            Assert.Equal(1799.9700M, orderDetail.LineItemTotal);
        }
    }
}