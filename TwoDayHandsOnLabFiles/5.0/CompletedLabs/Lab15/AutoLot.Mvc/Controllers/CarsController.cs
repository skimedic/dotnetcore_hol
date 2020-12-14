// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - CarsController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AutoLot.Mvc.Controllers
{
    [Route("[controller]/[action]")]
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int? id)
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            return View();
        }

        public IActionResult Delete(int? id)
        {
            return View();
        }
    }
}