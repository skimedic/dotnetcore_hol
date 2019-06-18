using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.Entities.Base;
using SpyStore.Hol.Models.ViewModels;
using SpyStore.Hol.Mvc.Controllers.Base;

namespace SpyStore.Hol.Mvc.Controllers
{
    public class CartController : BaseController
    {
        private readonly IShoppingCartRepo _shoppingCartRepo;
        public CartController(IShoppingCartRepo shoppingCartRepo)
        {
            _shoppingCartRepo = shoppingCartRepo;
        }
        public IActionResult Index([FromServices] ICustomerRepo customerRepo)
        {
            return null;
        }
        public IActionResult AddToCart([FromServices] IProductRepo productRepo,
            int productId, bool cameFromProducts = false)
        {
            return null;
        }

    }
}
