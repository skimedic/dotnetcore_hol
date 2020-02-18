#region copyright

// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal.Tests - CategoryRepoGetTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2019/10/04
// See License.txt for more information
// ==================================

#endregion

using System;
using Microsoft.EntityFrameworkCore;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Dal.Repos;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Dal.Tests.RepoTests.Base;
using SpyStore.Hol.Models.Entities;
using Xunit;

namespace SpyStore.Hol.Dal.Tests.RepoTests
{
    [Collection("SpyStore.DAL")]
    public class CategoryRepoGetTests : RepoTestsBase
    {
        private readonly ICategoryRepo _repo;

        public CategoryRepoGetTests()
        {
            _repo = new CategoryRepo(Db);
        }

        public override void Dispose()
        {
            _repo.Dispose();
        }

        [Fact]
        public void ShouldGetACategoryWithProductInfo()
        {
            var category = new Category {CategoryName = "Foo"};
            _repo.Add(category, true);
            //var cat = _repo.GetOneWithProducts(2);
            //Assert.Equal(2, cat.Products.Count());
        }

        [Fact]
        public void ShouldGetCategory()
        {
            var category = new Category {CategoryName = "Foo"};
            _repo.Add(category);
            _repo.Find(category.Id);
        }
    }
}