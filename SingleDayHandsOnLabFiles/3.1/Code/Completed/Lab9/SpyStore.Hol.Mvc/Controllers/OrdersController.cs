#region copyright

// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Mvc - OrdersController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2019/10/04
// See License.txt for more information
// ==================================

#endregion

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.ViewModels;
using SpyStore.Hol.Mvc.Controllers.Base;

namespace SpyStore.Hol.Mvc.Controllers
{
    [Route("[controller]/[action]")]
    public class OrdersController : BaseController
    {
        private readonly IOrderRepo _orderRepo;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger, IOrderRepo orderRepo)
        {
            _logger = logger;
            _orderRepo = orderRepo;
        }

        [Route("/Orders")]
        [Route("/Orders/Index")]
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Order History";
            ViewBag.Header = "Order History";
            _orderRepo.Context.CustomerId = ViewBag.CustomerId;
            IList<Order> orders = _orderRepo.GetOrderHistory().ToList();
            return View(orders);
        }

        [HttpGet("{orderId}")]
        public IActionResult Details(int orderId)
        {
            ViewBag.Title = "Order Details";
            ViewBag.Header = "Order Details";
            OrderWithDetailsAndProductInfo orderDetails = _orderRepo.GetOneWithDetails(orderId);
            if (orderDetails == null) return NotFound();
            return View(orderDetails);
        }
    }
}