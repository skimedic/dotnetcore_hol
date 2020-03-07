// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Mvc - ProductsController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Mvc.Controllers.Base;
using SpyStore.Hol.Mvc.Support;

namespace SpyStore.Hol.Mvc.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductRepo _productRepo;
        private readonly CustomSettings _settings;

        public ProductsController(
            ILogger<ProductsController> logger,
            IProductRepo productRepo,
            IOptionsMonitor<CustomSettings> settings)
        {
            _settings = settings.CurrentValue;
            _logger = logger;
            _productRepo = productRepo;
        }
    }
}