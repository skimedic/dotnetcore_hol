﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Models.Entities;

namespace SpyStore.Hol.Dal.Initialization
{
    public static class SampleDataInitializer
    {
        public static void DropAndCreateDatabase(StoreContext context)
        {
            context.Database.EnsureDeleted();
            //This doesn't run the migrations, so SQL objects will be missing
            //DON'T USE THIS => context.Database.EnsureCreated();
            context.Database.Migrate();
        }

        internal static void ResetIdentity(StoreContext context)
        {
            var tables = new[]
            {
                "Categories", "Customers",
                "OrderDetails", "Orders", "Products", "ShoppingCartRecords"
            };
            foreach (var itm in tables)
            {
                var rawSqlString = $"DBCC CHECKIDENT (\"Store.{itm}\", RESEED, 0);";
                context.Database.ExecuteSqlRaw(rawSqlString);
            }
        }

        public static void ClearData(StoreContext context)
        {
            context.Database.ExecuteSqlRaw("Delete from Store.Categories");
            context.Database.ExecuteSqlRaw("Delete from Store.Customers");
            ResetIdentity(context);
        }


        internal static void SeedData(StoreContext context)
        {
            try
            {
                var cust = new Customer()
                {
                    EmailAddress = "spy@secrets.com",
                    Password = "Foo",
                    FullName = "Super Spy",
                };
                if (!context.Customers.Any())
                {
                    context.Customers.Add(cust);
                    context.SaveChanges();
                }
                if (!context.Categories.Any())
                {
                    foreach (var itm in SampleData.GetCategories())
                    {
                        context.Categories.Add(itm.Cat);
                        context.SaveChanges();
                        itm.Cat.Products.AddRange(itm.Products);
                        context.SaveChanges();
                    }
                    //context.Categories.AddRange();
                    //context.SaveChanges();
                }

                if (!context.Customers.Any())
                {
                    var prod1 = context.Categories
                        .Include(c => c.Products).FirstOrDefault()?
                        .Products.Skip(3).FirstOrDefault();
                    var prod2 = context.Categories.Skip(2)
                        .Include(c => c.Products).FirstOrDefault()?
                        .Products.Skip(2).FirstOrDefault();
                    var prod3 = context.Categories.Skip(5)
                        .Include(c => c.Products).FirstOrDefault()?
                        .Products.Skip(1).FirstOrDefault();
                    var prod4 = context.Categories.Skip(2)
                        .Include(c => c.Products).FirstOrDefault()?
                        .Products.Skip(1).FirstOrDefault();

                    context.Customers.Update(SampleData.GetAllCustomerRecords(cust,
                        new List<Product> {prod1, prod2, prod3, prod4}));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public static void InitializeData(StoreContext context)
        {
            //Ensure the database exists and is up to date
            context.Database.EnsureDeleted();
            context.Database.Migrate();
            ClearData(context);
            SeedData(context);
        }
    }
}