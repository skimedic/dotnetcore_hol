using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpyStore.Hol.Mvc.Models;

namespace SpyStore.Hol.Mvc.Controllers
{
    [Route("[controller]/[action]/{id?}")]
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("/Home")]
        [Route("/Home/Index")]
        [Route("/Home/Index/{id?}")]
        public IActionResult Index(int? id)
        {
            return View();
        }

        //[Route("[controller]/[action]/{id?}")]
        [HttpGet("/[action]/[controller]/{id?}")]
        public IActionResult Test(int? id)
        {
            return View("Index");
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
