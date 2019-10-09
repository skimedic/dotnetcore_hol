#region copyright

// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Mvc - Startup.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2019/10/04
// See License.txt for more information
// ==================================

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Dal.Initialization;
using SpyStore.Hol.Dal.Repos;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Mvc.Support;

namespace SpyStore.Hol.Mvc
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            var connectionString = Configuration.GetConnectionString("SpyStore");
            services.AddDbContextPool<StoreContext>(options => options
                .UseSqlServer(connectionString, o => o.EnableRetryOnFailure()));
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<IShoppingCartRepo, ShoppingCartRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IOrderDetailRepo, OrderDetailRepo>();
            services.Configure<CustomSettings>(Configuration.GetSection("CustomSettings"));
            if (_env.IsDevelopment() || _env.EnvironmentName == "Local")
            {
                //services.AddWebOptimizer(false,false);
                services.AddWebOptimizer(options =>
                {
                    options.MinifyCssFiles(); //Minifies all CSS files
                    //options.MinifyJsFiles(); //Minifies all JS files
                    options.MinifyJsFiles("js/site.js");
                    options.AddJavaScriptBundle("js/validations/validationCode.js", "js/validations/**/*.js");
                });
            }
            else
            {
                services.AddWebOptimizer(options =>
                {
                    options.MinifyCssFiles(); //Minifies all CSS files
                    //options.MinifyJsFiles(); //Minifies all JS files
                    options.MinifyJsFiles("js/site.js");
                    options.AddJavaScriptBundle("js/validations/validationCode.js", "js/validations/**/*.js");
                });
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsEnvironment("Local"))
            {
                app.UseDeveloperExceptionPage();
                using (var serviceScope = app.ApplicationServices
                    .GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    SampleDataInitializer.InitializeData(
                        serviceScope.ServiceProvider.GetRequiredService<StoreContext>());
                }
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseWebOptimizer();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}