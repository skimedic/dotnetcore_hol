// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - ApplicationDbContext.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System;
using AutoLot.Models.Entities;
using AutoLot.Models.Entities.Owned;
using AutoLot.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AutoLot.Dal.EfStructures
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public int MakeId { get; set; }
        public DbSet<SeriLogEntry>? LogEntries { get; set; }
        public DbSet<CreditRisk>? CreditRisks { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Make>? Makes { get; set; }
        public DbSet<Car>? Cars { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<CustomerOrderViewModel>? CustomerOrderViewModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SeriLogEntry>(entity =>
            {
                entity.Property(e => e.Properties).HasColumnType("Xml");
                entity.Property(e => e.TimeStamp).HasDefaultValueSql("GetDate()");
            });
            //modelBuilder.Entity<SeriLogEntry>(entity =>
            //{
            //    entity.ToTable("Serilog", "Logging", t => t.ExcludeFromMigrations());
            //});

            modelBuilder.Entity<Car>().HasQueryFilter(c => c.MakeId == MakeId); 
            //New in EF Core 5 - bi-directional query filters
            modelBuilder.Entity<Order>().HasQueryFilter(e => e.CarNavigation!.MakeId == MakeId);

            modelBuilder.Entity<CustomerOrderViewModel>().HasNoKey().ToView("CustomerOrderView", "dbo");
            //modelBuilder.Entity<CustomerOrderViewModel>(entity =>
            //{
            //    entity.HasNoKey().ToSqlQuery(@"SELECT c.FirstName, c.LastName, i.Color, i.PetName, m.Name AS Make
            //            FROM   dbo.Orders o
            //            INNER JOIN dbo.Customers c ON o.CustomerId = c.Id 
            //            INNER JOIN dbo.Inventory  i ON o.CarId = i.Id
            //            INNER JOIN dbo.Makes m ON m.Id = i.MakeId
            //            ");
            //});

            modelBuilder.Entity<CreditRisk>(entity =>
            {
                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p!.CreditRisks)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CreditRisks_Customers");
                entity.OwnsOne(o => o.PersonalInformation,
                    pd =>
                    {
                        pd.Property<string>(nameof(Person.FirstName))
                            .HasColumnName(nameof(Person.FirstName))
                            .HasColumnType("nvarchar(50)");
                        pd.Property<string>(nameof(Person.LastName))
                            .HasColumnName(nameof(Person.LastName))
                            .HasColumnType("nvarchar(50)");
                    });
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.OwnsOne(o => o.PersonalInformation,
                    pd =>
                    {
                        pd.Property(p => p.FirstName).HasColumnName(nameof(Person.FirstName));
                        pd.Property(p => p.LastName).HasColumnName(nameof(Person.LastName));
                    });
            });

            modelBuilder.Entity<Make>(entity =>
            {
                entity.HasMany(e => e.Cars)
                    .WithOne(c => c.MakeNavigation!)
                    .HasForeignKey(k => k.MakeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Make_Inventory");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.CarNavigation)
                    .WithMany(p => p!.Orders)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Inventory");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p!.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Orders_Customers");
                entity.HasIndex(cr => new {cr.CustomerId, cr.CarId}).IsUnique(true);
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
