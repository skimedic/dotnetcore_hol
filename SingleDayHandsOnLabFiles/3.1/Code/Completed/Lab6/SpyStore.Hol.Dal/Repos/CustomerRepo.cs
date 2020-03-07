// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal - CustomerRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Dal.Repos.Base;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Models.Entities;

namespace SpyStore.Hol.Dal.Repos
{
    public class CustomerRepo : RepoBase<Customer>, ICustomerRepo
    {
        public CustomerRepo(StoreContext context) : base(context)
        {
        }

        internal CustomerRepo(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public override IEnumerable<Customer> GetAll() => base.GetAll(x => x.FullName).ToList();
    }
}