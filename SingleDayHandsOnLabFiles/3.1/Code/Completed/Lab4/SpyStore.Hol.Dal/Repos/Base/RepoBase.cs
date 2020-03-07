// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal - RepoBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Dal.Exceptions;
using SpyStore.Hol.Models.Entities.Base;

namespace SpyStore.Hol.Dal.Repos.Base
{
    public abstract class RepoBase<T> : IRepo<T> where T : EntityBase, new()
    {
        private readonly bool _disposeContext;

        protected RepoBase(StoreContext context)
        {
            Context = context;
            Table = Context.Set<T>();
            _disposeContext = false;
        }

        protected RepoBase(DbContextOptions<StoreContext> options) : this(new StoreContext(options))
        {
            _disposeContext = true;
        }

        public DbSet<T> Table { get; }
        public StoreContext Context { get; }

        public virtual void Dispose()
        {
            if (_disposeContext)
            {
                Context.Dispose();
            }
        }

        public T Find(int? id) => Table.Find(id);
        public T FindAsNoTracking(int id) => Table.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
        public T FindIgnoreQueryFilters(int id) => Table.IgnoreQueryFilters().FirstOrDefault(x => x.Id == id);
        public virtual IEnumerable<T> GetAll() => Table;

        public virtual IEnumerable<T> GetAll(Expression<Func<T, object>> orderBy)
            => Table.OrderBy(orderBy);

        public IEnumerable<T> GetRange(IQueryable<T> query, int skip, int take)
            => query.Skip(skip).Take(take);

        public virtual int Add(T entity, bool persist = true)
        {
            Table.Add(entity);
            return persist ? SaveChanges() : 0;
        }

        public virtual int AddRange(IEnumerable<T> entities, bool persist = true)
        {
            Table.AddRange(entities);
            return persist ? SaveChanges() : 0;
        }

        public virtual int Update(T entity, bool persist = true)
        {
            Table.Update(entity);
            return persist ? SaveChanges() : 0;
        }

        public virtual int UpdateRange(IEnumerable<T> entities, bool persist = true)
        {
            Table.UpdateRange(entities);
            return persist ? SaveChanges() : 0;
        }

        public virtual int Delete(T entity, bool persist = true)
        {
            Table.Remove(entity);
            return persist ? SaveChanges() : 0;
        }

        public virtual int DeleteRange(IEnumerable<T> entities, bool persist = true)
        {
            Table.RemoveRange(entities);
            return persist ? SaveChanges() : 0;
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
    }
}