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
        private readonly IProductRepo _productRepo;
        private readonly CustomSettings _settings;

        public ProductsController(
            IProductRepo productRepo,
            IOptionsSnapshot<CustomSettings> settings)
        {
            _settings = settings.Value;
            _productRepo = productRepo;
        }

    }
}
