using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.ViewModels;
using SpyStore.Hol.Mvc.Controllers.Base;

namespace SpyStore.Hol.Mvc.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IOrderRepo _orderRepo;
        public OrdersController(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

    }
}
