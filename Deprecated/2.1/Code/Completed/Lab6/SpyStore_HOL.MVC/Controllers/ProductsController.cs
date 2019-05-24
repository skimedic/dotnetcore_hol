using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpyStore_HOL.DAL.Repos.Interfaces;
using SpyStore_HOL.MVC.Support;

namespace SpyStore_HOL.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepo _productRepo;
        private readonly CustomSettings _settings;
        private ILogger Logger { get; }

        public ProductsController(
            IProductRepo productRepo,
            IOptionsSnapshot<CustomSettings> settings,
            ILogger<ProductsController> logger)
        {
            _settings = settings.Value;
            _productRepo = productRepo;
            Logger = logger;
        }

    }
}