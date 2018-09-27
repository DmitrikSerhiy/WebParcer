using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebParcer.Helpers;
using WebParcer.Models;

namespace WebParcer.Controllers
{
    // [Controller]
    [Route("home")]
    public class HomeController : Controller
    {
        private List<(string, string)> urlAndTitles;
        private static object locker = new object();
        private List<Task> tasks;

        public HomeController()
        {
            urlAndTitles = new List<(string, string)>();
            tasks = new List<Task>();
        }
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("titles")]
        public IActionResult Titles(UnparcedUrlModel model)
        {
            var urls = UrlParser.Parse(model);

            InitTitles(urls);
            Task.WaitAll(tasks.ToArray());

            var models = ParcedModelBuilder.FormModels(urlAndTitles);

            if (models != null) return View(models);
            return BadRequest();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        protected void InitTitles(string[] urls)
        {
            foreach (var url in urls)
            {
                var task = PageLoager.LoadTitleAsync(url);
                tasks.Add(task);

                Monitor.Enter(locker);
                urlAndTitles.Add( (url, task.GetAwaiter().GetResult()) );
                Monitor.Exit(locker);
            }
        }
    }
}
