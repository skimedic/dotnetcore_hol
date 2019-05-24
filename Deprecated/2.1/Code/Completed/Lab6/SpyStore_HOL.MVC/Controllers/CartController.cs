using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpyStore_HOL.DAL.Repos.Interfaces;

namespace SpyStore_HOL.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly IShoppingCartRepo _shoppingCartRepo;
        readonly MapperConfiguration _config = null;
        public CartController(IShoppingCartRepo shoppingCartRepo)
        {
            _shoppingCartRepo = shoppingCartRepo;
        }
        public IActionResult Index([FromServices] ICustomerRepo customerRepo, int customerId)
        {
            return null;
        }
        public IActionResult AddToCart([FromServices] IProductRepo productRepo, int customerId, int productId, bool cameFromProducts = false)
        {
            return null;
        }

    }
}