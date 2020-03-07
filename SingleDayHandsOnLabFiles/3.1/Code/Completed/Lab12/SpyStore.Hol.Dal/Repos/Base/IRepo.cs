// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal - IRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Models.Entities.Base;

namespace SpyStore.Hol.Dal.Repos.Base
{
    public interface IRepo<T> : IDisposable where T : EntityBase, new()
    {
        DbSet<T> Table { get; }
        StoreContext Context { get; }
        int Add(T entity, bool persist = true);
        int AddRange(IEnumerable<T> entities, bool persist = true);
        int Delete(T entity, bool persist = true);
        int DeleteRange(IEnumerable<T> entities, bool persist = true);
        T Find(int? id);
        T FindAsNoTracking(int id);
        T FindIgnoreQueryFilters(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, object>> orderBy);
        IEnumerable<T> GetRange(IQueryable<T> query, int skip, int take);
        int SaveChanges();
        int Update(T entity, bool persist = true);
        int UpdateRange(IEnumerable<T> entities, bool persist = true);
    }
}