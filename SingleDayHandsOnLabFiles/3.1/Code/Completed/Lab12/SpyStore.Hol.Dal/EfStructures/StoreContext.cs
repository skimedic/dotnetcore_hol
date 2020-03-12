// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal - StoreContext.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

using System;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SpyStore.Hol.Dal.Exceptions;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.Entities.Base;
using SpyStore.Hol.Models.ViewModels;

namespace SpyStore.Hol.Dal.EfStructures
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
            //this.ChangeTracker.StateChanged += ChangeTracker_StateChanged;
            //this.ChangeTracker.Tracked+= ChangeTrackerOnTracked;
        }

        public int CustomerId { get; set; }

        public DbSet<CartRecordWithProductInfo> CartRecordWithProductInfos { get; set; }
        public DbSet<OrderDetailWithProductInfo> OrderDetailWithProductInfos { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartRecord> ShoppingCartRecords { get; set; }

        [DbFunction("GetOrderTotal", Schema = "Store")]
        public static int GetOrderTotal(int orderId)
        {
            //code in here doesn’t matter since it never gets executed
            throw new Exception();
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //A concurrency error occurred
                //Should log and handle intelligently
                throw new SpyStoreConcurrencyException("A concurrency error happened.", ex);
            }
            catch (RetryLimitExceededException ex)
            {
                //DbResiliency retry limit exceeded
                //Should log and handle intelligently
                throw new SpyStoreRetryLimitExceededException("There is a problem with you connection.", ex);
            }
            catch (DbUpdateException ex)
            {
                //Should log and handle intelligently
                if (ex.InnerException is SqlException sqlException)
                {
                    if (sqlException.Message.Contains("FOREIGN KEY constraint", StringComparison.OrdinalIgnoreCase))
                    {
                        if (sqlException.Message.Contains("table \"Store.Products\", column 'Id'",
                            StringComparison.OrdinalIgnoreCase))
                        {
                            throw new SpyStoreInvalidProductException($"Invalid Product Id\r\n{ex.Message}", ex);
                        }

                        if (sqlException.Message.Contains("table \"Store.Customers\", column 'Id'",
                            StringComparison.OrdinalIgnoreCase))
                        {
                            throw new SpyStoreInvalidCustomerException($"Invalid Customer Id\r\n{ex.Message}", ex);
                        }
                    }
                }

                throw new SpyStoreException("An error occurred updating the database", ex);
            }
            catch (Exception ex)
            {
                //Should log and handle intelligently
                throw new SpyStoreException("An error occurred updating the database", ex);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartRecordWithProductInfo>()
                .ToView("CartRecordWithProductInfo", "Store").HasNoKey();
            modelBuilder.Entity<OrderDetailWithProductInfo>()
                .ToView("OrderDetailWithProductInfo", "Store").HasNoKey();

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.EmailAddress).HasName("IX_Customers").IsUnique();
            });
            modelBuilder.Entity<Order>().HasQueryFilter(x => x.CustomerId == CustomerId);
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderDate).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(e => e.ShipDate).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(e => e.OrderTotal)
                    .HasColumnType("money")
                    .HasComputedColumnSql("Store.GetOrderTotal([Id])");
            });
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.UnitCost).HasColumnType("money");
                entity.Property(e => e.LineItemTotal).HasColumnType("money")
                    .HasComputedColumnSql("[Quantity]*[UnitCost]");
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.UnitCost).HasColumnType("money");
                entity.Property(e => e.CurrentPrice).HasColumnType("money");
                entity.OwnsOne(o => o.Details,
                    pd =>
                    {
                        pd.Property(p => p.Description).HasColumnName(nameof(ProductDetails.Description));
                        pd.Property(p => p.ModelName).HasColumnName(nameof(ProductDetails.ModelName));
                        pd.Property(p => p.ModelNumber).HasColumnName(nameof(ProductDetails.ModelNumber));
                        pd.Property(p => p.ProductImage).HasColumnName(nameof(ProductDetails.ProductImage));
                        pd.Property(p => p.ProductImageLarge).HasColumnName(nameof(ProductDetails.ProductImageLarge));
                        pd.Property(p => p.ProductImageThumb).HasColumnName(nameof(ProductDetails.ProductImageThumb));
                    });
            });
            modelBuilder.Entity<ShoppingCartRecord>().HasQueryFilter(x => x.CustomerId == CustomerId);
            modelBuilder.Entity<ShoppingCartRecord>(entity =>
            {
                entity.HasIndex(e => new {ShoppingCartRecordId = e.Id, e.ProductId, e.CustomerId})
                    .HasName("IX_ShoppingCart").IsUnique();
                entity.Property(e => e.DateCreated).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(e => e.Quantity).HasDefaultValue(1);
            });
        }

        private void ChangeTracker_StateChanged(object sender,
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityStateChangedEventArgs e) =>
            throw new NotImplementedException();

        private void ChangeTrackerOnTracked(object sender, EntityTrackedEventArgs e)
        {
            if (e.Entry.Entity is EntityBase)
            {
            }

            //throw new NotImplementedException();
        }
    }
}