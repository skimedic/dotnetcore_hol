using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Dal.Exceptions;
using SpyStore.Hol.Dal.Repos.Base;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.ViewModels;

namespace SpyStore.Hol.Dal.Repos
{
    public class ShoppingCartRepo : RepoBase<ShoppingCartRecord>, IShoppingCartRepo
    {
        private readonly IProductRepo _productRepo;
        private readonly ICustomerRepo _customerRepo;
        internal ShoppingCartRepo(StoreContext context, 
            IProductRepo productRepo, 
            ICustomerRepo customerRepo) : base(context)
        {
            _productRepo = productRepo;
            _customerRepo = customerRepo;
        }

        public ShoppingCartRepo(DbContextOptions<StoreContext> options, 
            IProductRepo productRepo, 
            ICustomerRepo customerRepo) : this(new StoreContext(options),productRepo,customerRepo)
        {
        }

        public override IEnumerable<ShoppingCartRecord> GetAll()
            => base.GetAll(x => x.DateCreated).ToList();

        public ShoppingCartRecord GetBy(int productId)
            => Table.FirstOrDefault(x => x.ProductId == productId);

        public CartRecordWithProductInfo GetShoppingCartRecord(int id)
            => Context
                .CartRecordWithProductInfos
                .FirstOrDefault(x => x.Id == id);

        public IEnumerable<CartRecordWithProductInfo> GetShoppingCartRecords(int customerId)
            => Context
                .CartRecordWithProductInfos
                .Where(x => x.CustomerId == customerId)
                .OrderBy(x => x.ModelName);

        public CartWithCustomerInfo GetShoppingCartRecordsWithCustomer(int customerId)
            => new CartWithCustomerInfo()
            {
                CartRecords = GetShoppingCartRecords(customerId).ToList(),
                Customer = _customerRepo.Find(customerId)
            };

        public override int Update(ShoppingCartRecord entity, bool persist = true)
            => Update(entity, _productRepo.FindAsNoTracking(entity.ProductId)?.UnitsInStock, persist);

        public int Update(ShoppingCartRecord entity, int? quantityInStock, bool persist = true)
        {
            if (entity.Quantity <= 0)
            {
                return Delete(entity, persist);
            }
            if (entity.Quantity > quantityInStock)
            {
                throw new SpyStoreInvalidQuantityException("Can't add more product than available in stock");
            }

            var dbRecord = Find(entity.Id);
            if (entity.TimeStamp != null && dbRecord.TimeStamp.SequenceEqual(entity.TimeStamp))
            {
                dbRecord.Quantity = entity.Quantity;
                return base.Update(dbRecord, persist);
            }
            throw new SpyStoreConcurrencyException("Record was changed since it was loaded");
        }

        public override int UpdateRange(IEnumerable<ShoppingCartRecord> entities, bool persist = true)
        {
            int counter = 0;
            foreach (var item in entities)
            {
                var product = _productRepo.FindAsNoTracking(item.ProductId);
                counter += Update(item, product?.UnitsInStock, false);
            }

            return persist ? SaveChanges() : counter;
        }

        public override int Add(ShoppingCartRecord entity, bool persist = true)
            => Add(entity, _productRepo.Find(entity.ProductId)?.UnitsInStock, persist);

        public int Add(ShoppingCartRecord entity, int? quantityInStock, bool persist = true)
        {
            var item = GetBy(entity.ProductId);
            if (item == null)
            {
                if (quantityInStock != null && entity.Quantity > quantityInStock.Value)
                {
                    throw new SpyStoreInvalidQuantityException("Can't add more product than available in stock");
                }
                return base.Add(entity, persist);
            }
            item.Quantity += entity.Quantity;
            return item.Quantity <= 0 ? Delete(item, persist) : Update(item, quantityInStock, persist);
        }

        public override int AddRange(IEnumerable<ShoppingCartRecord> entities, bool persist = true)
        {
            int counter = 0;
            foreach (var item in entities)
            {
                var product = _productRepo.FindAsNoTracking(item.ProductId);
                counter += Add(item, product?.UnitsInStock, false);
            }

            return persist ? SaveChanges() : counter;
        }

        public int Purchase(int customerId)
        {
            var customerIdParam = new SqlParameter("@customerId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = customerId
            };
            var orderIdParam = new SqlParameter("@orderId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            try
            {
                Context.Database.ExecuteSqlCommand("EXEC [Store].[PurchaseItemsInCart] @customerId, @orderid out", customerIdParam, orderIdParam);
            }
            catch (Exception ex)
            {
                return -1;
            }
            return (int)orderIdParam.Value;
        }
    }
}
