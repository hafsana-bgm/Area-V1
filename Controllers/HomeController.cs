using System.Diagnostics;
using Area_v1.Data;
using Area_v1.Helper;
using Area_v1.Models;
using Area_v1.ViewModel;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
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


        [HttpPost]

        public IActionResult AddToCart([FromBody] int ProductId)
        {

            var product = _context.Lookups.FirstOrDefault(a => a.ProductId == ProductId);
            if (product == null)
            {
                return Json(new { Success = false, msg = "Product not found" });
            }
            var cart = HttpContext.Session.SetObjectAsJson<List<CartItem>>("Shop") ?? new List<CartItem>();
            var CartItem = cart.FirstOrDefault(x => x.ProductId == ProductId);

            if (cart == null)
            {
                cart.Add(new CartItem
                {
                    ProductId = product.ProductId,
                    Name = product.ProductName,
                    Price = product.ProductPrice,
                    Quantity = 1
                });
            }
            else
            {
                CartItem.Quantity++;
            }

            HttpContext.Session.SetObjectAsJson("Shop", cart);

            return Json(new { Success = true, msg = "Product found" });

        }





        [HttpGet]
        public IActionResult GetCartCount()
        {

            var cart = HttpContext.Session.SetObjectAsJson<List<CartItem>>("Shop") ?? new List<CartItem>();
            int count = cart.Sum(x => x.Quantity);

            return Json(cart.Sum(x => x.Quantity));
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
