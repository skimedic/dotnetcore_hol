// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal.Tests - OrderRepoTests.cs
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
    public class OrderRepoTests : RepoTestsBase
    {
        public OrderRepoTests()
        {
            _repo = new OrderRepo(Db, new OrderDetailRepo(Db));
            Db.CustomerId = 1;
            LoadDatabase();
        }

        private readonly IOrderRepo _repo;

        public override void Dispose()
        {
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