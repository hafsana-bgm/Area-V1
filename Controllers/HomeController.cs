using System.Diagnostics;
using Area_v1.Data;
using Area_v1.Models;
using Area_v1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Area_v1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BAreaContext _context;
        public HomeController(ILogger<HomeController> logger, BAreaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var allproducts = _context.Lookups.Take(10).ToList();

            var viewmodel = new HomeVM();

            viewmodel.LookUp = allproducts;

            return View(viewmodel);
        }



        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Admin()
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
