using Microsoft.Extensions.Configuration;
using SpyStore.Hol.Mvc.Controllers.Base;
using SpyStore.Hol.Mvc.Support;

namespace SpyStore.Hol.Mvc.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly SpyStoreServiceWrapper _serviceWrapper;
        public ProductsController(SpyStoreServiceWrapper serviceWrapper, IConfiguration configuration) : base(configuration)
        {
            _serviceWrapper = serviceWrapper;
        }

    }
}
