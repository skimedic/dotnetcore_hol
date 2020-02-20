using Microsoft.Extensions.Configuration;
using SpyStore.Hol.Mvc.Controllers.Base;
using SpyStore.Hol.Mvc.Support;

namespace SpyStore.Hol.Mvc.Controllers
{
    public class CartController : BaseController
    {
        private readonly SpyStoreServiceWrapper _serviceWrapper;

        public CartController(SpyStoreServiceWrapper serviceWrapper, IConfiguration configuration) : base(configuration)
        {
            _serviceWrapper = serviceWrapper;
        }
    }
}