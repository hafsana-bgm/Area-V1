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

            viewmodel.Products = _context.Product.ToList();

            viewmodel.LookUp = allproducts;
           
            return View(viewmodel);
        }


      




        //[HttpGet]
        //public IActionResult GetCartCount()
        //{

        //    var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Shop") ?? new List<CartItem>();
        //    int count = cart.Sum(x => x.Quantity);

        //    return Json(cart.Sum(x => x.Quantity));
        //}



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


        [HttpPost]
        public IActionResult AddToWant([FromBody]int productId)
        {

            var product = _context.Product.FirstOrDefault(x => x.ProductId == productId);
            if (product == null)
            {
                return Json(new { success = false, Msg = "Error" });
            }

            var cart = HttpContext.Session.GetObjectFromJson<List<CartItemVM>>("Cart") ?? new List<CartItemVM>();

            var CartItem = cart.FirstOrDefault(a => a.ProductId==productId);

            if (CartItem == null)
            {
                cart.Add(new CartItemVM
                {
                    ProductId = product.ProductId,
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    Quantity = 1

                });

            }
            else
            {
                CartItem.Quantity++;

            }


            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return Json(new { success = true, Msg = "Success" });
        }

        [HttpGet]
        public IActionResult GetCartCount()
        {
           var cart = HttpContext.Session.GetObjectFromJson<List<CartItemVM>>("Cart") ?? new List<CartItemVM>();

            int count = cart.Sum(x => x.Quantity);

            return Json(count);
        }

        [HttpGet]
        public IActionResult TotalCount()
        {
           var cart = HttpContext.Session.GetObjectFromJson<List<Product>>("Cart") ?? new List<Product>();

           double count = cart.Sum(x => x.Price);

            return Json(count);
        }




        public IActionResult ProductCart()
        {
            var product = _context.Product.ToList();

            return View(product);
        }
        public IActionResult CartDelete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Product.FirstOrDefault(x => x.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("ProductCart");

        }

    }
}
