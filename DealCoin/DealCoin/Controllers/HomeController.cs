using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DealCoin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["NoLayout"] = true;
            return View();
            // lala
        }
    }
}
