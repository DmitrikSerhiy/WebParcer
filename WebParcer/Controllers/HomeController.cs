using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebParcer.Models;

namespace WebParcer.Controllers
{
   // [Controller]
    [Route("home")]
    public class HomeController : Controller
    {
        
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("titles")]
        public IActionResult Titles(ParcedPageModel model)
        {
            var list = new List<ParcedPageModel>() { model };
            return View(list);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
