using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.Entities.Base;
using SpyStore.Hol.Models.ViewModels;
using SpyStore.Hol.Mvc.Controllers.Base;
using SpyStore.Hol.Mvc.Models.ViewModels;
using SpyStore.Hol.Mvc.Support;

namespace SpyStore.Hol.Mvc.Controllers
{
    [Route("[controller]/[action]")]
    //[Route("ShoppingCart/[action]")]
    public class CartController : BaseController
    {
        private readonly SpyStoreServiceWrapper _serviceWrapper;

        readonly MapperConfiguration _config = null;
        public CartController(SpyStoreServiceWrapper serviceWrapper, IConfiguration configuration) : base(configuration)
        {
            _serviceWrapper = serviceWrapper;
            _config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<AddToCartViewModel, ShoppingCartRecord>()
                        .AfterMap((s, t) =>
                        {
                            t.Id = 0;
                            t.TimeStamp = null;
                        });
                    cfg.CreateMap<CartRecordWithProductInfo, CartRecordViewModel>();
                    cfg.CreateMap<Product, AddToCartViewModel>()
                        .ForMember(x => x.Description, x => x.MapFrom(src => src.Details.Description))
                        .ForMember(x => x.ModelName, x => x.MapFrom(src => src.Details.ModelName))
                        .ForMember(x => x.ModelNumber, x => x.MapFrom(src => src.Details.ModelNumber))
                        .ForMember(x => x.ProductImage, x => x.MapFrom(src => src.Details.ProductImage))
                        .ForMember(x => x.ProductImageLarge, x => x.MapFrom(src => src.Details.ProductImageLarge))
                        .ForMember(x => x.ProductImageThumb, x => x.MapFrom(src => src.Details.ProductImageThumb));
                });
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Cart";
            ViewBag.Header = "Cart";
            CartWithCustomerInfo cartWithCustomerInfo = await _serviceWrapper.GetCartAsync(ViewBag.CustomerId);
            var mapper = _config.CreateMapper();
            var viewModel = new CartViewModel
            {
                Customer = cartWithCustomerInfo.Customer,
                CartRecords = mapper.Map<IList<CartRecordViewModel>>(cartWithCustomerInfo.CartRecords)
            };
            return View(viewModel);
        }
        //[HttpGet("{productId}")]
        //public IActionResult AddToCart([FromServices] IProductRepo productRepo,
        //    int productId, bool cameFromProducts = false)
        //{
        //    ViewBag.CameFromProducts = cameFromProducts;
        //    ViewBag.Title = "Add to Cart";
        //    ViewBag.Header = "Add to Cart";
        //    ViewBag.ShowCategory = true;
        //    var prod = productRepo.GetOneWithCategoryName(productId);
        //    if (prod == null) return NotFound();
        //    var mapper = _config.CreateMapper();
        //    AddToCartViewModel cartRecord = mapper.Map<AddToCartViewModel>(prod);
        //    cartRecord.Quantity = 1;
        //    return View(cartRecord);
        //}
        //[HttpPost("{productId}"), ValidateAntiForgeryToken]
        //public IActionResult AddToCart(int productId, AddToCartViewModel item)
        //{
        //    if (!ModelState.IsValid) return View(item);
        //    try
        //    {
        //        var mapper = _config.CreateMapper();
        //        var cartRecord = mapper.Map<ShoppingCartRecord>(item);
        //        cartRecord.DateCreated = DateTime.Now;
        //        _shoppingCartRepo.Context.CustomerId = ViewBag.CustomerId;
        //        _shoppingCartRepo.Add(cartRecord);
        //    }
        //    catch (Exception)
        //    {
        //        ModelState.AddModelError(string.Empty, "There was an error adding the item to the cart.");
        //        return View(item);
        //    }
        //    return RedirectToAction(nameof(CartController.Index));
        //}
        [HttpPost("{id}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, CartRecordViewModel record)
        {
            var cartRecord = new ShoppingCartRecord
            {
                Id = record.Id,
                Quantity = record.Quantity,
                ProductId = record.ProductId,
                TimeStamp = record.TimeStamp,
                CustomerId = record.CustomerId
            };
            var item = await _serviceWrapper.UpdateShoppingCartRecord(id, cartRecord);
            var mapper = _config.CreateMapper();
            CartRecordViewModel vm = mapper.Map<CartRecordViewModel>(item);
            return PartialView(vm);

        }
        //[HttpPost("{id}"), ValidateAntiForgeryToken]
        //public IActionResult Delete(int customerId, int id, ShoppingCartRecord item)
        //{
        //    _shoppingCartRepo.Context.CustomerId = ViewBag.CustomerId;
        //    _shoppingCartRepo.Delete(item);
        //    return RedirectToAction(nameof(Index), new { customerId });
        //}

        //[HttpPost, ValidateAntiForgeryToken]
        //public async Task<IActionResult> Buy()
        //{
        //    int orderId = _shoppingCartRepo.Purchase(ViewBag.CustomerId);
        //    return RedirectToAction(
        //        nameof(OrdersController.Details),
        //        nameof(OrdersController).Replace("Controller", ""),
        //        new { orderId });
        //}

    }
}
