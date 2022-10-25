using ASM.Interface;
using ASM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMonAn monAnSvc;

        public HomeController(ILogger<HomeController> logger, IMonAn monAnSvc)
        {
            _logger = logger;
            this.monAnSvc = monAnSvc;
        }

        public async Task<IActionResult> Index()
        {
            return View(await monAnSvc.GetMonAnAllAsync());
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Review()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
       
        public async Task<IActionResult> Monan()
        {
            return View(await monAnSvc.GetMonAnAllAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
