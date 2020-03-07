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
    [Route("[controller]/[action]")]
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

        public ActionResult Details(int id)
        {
            return RedirectToAction(nameof(CartController.AddToCart),
                nameof(CartController).Replace("Controller", ""),
                new
                {
                    productId = id,
                    cameFromProducts = true
                });
        }

        [HttpGet]
        public IActionResult Featured()
        {
            ViewBag.Foo = _settings.MySetting1;
            ViewBag.Title = "Featured Products";
            ViewBag.Header = "Featured Products";
            ViewBag.ShowCategory = true;
            ViewBag.Featured = true;
            return View("ProductList", _productRepo.GetFeaturedWithCategoryName());
        }

        [Route("/")]
        [Route("/Products")]
        [Route("/Products/Index")]
        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction(nameof(Featured));
        }

        [HttpGet]
        public IActionResult ProductList([FromServices] ICategoryRepo categoryRepo, int id)
        {
            var cat = categoryRepo.Find(id);
            ViewBag.Title = cat?.CategoryName;
            ViewBag.Header = cat?.CategoryName;
            ViewBag.ShowCategory = false;
            ViewBag.Featured = false;
            return View(_productRepo.GetProductsForCategory(id));
        }

        //[Route("[controller]/[action]/{searchString}")]
        //[HttpPost]
        [Route("[controller]/[action]")]
        [HttpPost("{searchString}")]
        public IActionResult Search(string searchString)
        {
            ViewBag.Title = "Search Results";
            ViewBag.Header = "Search Results";
            ViewBag.ShowCategory = true;
            ViewBag.Featured = false;
            return View("ProductList", _productRepo.Search(searchString));
        }
    }
}