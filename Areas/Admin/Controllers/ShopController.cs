using System.Reflection.Emit;
using Area_v1.Areas.Admin.Data;
using Area_v1.Areas.Admin.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Area_v1.Areas.Shop.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    [Route("Admin/[Controller]")]

    public class ShopController : Controller
    {
        public readonly BAreaContext _context;
        public ShopController(BAreaContext context)
        {
            _context = context;
        }



        [Route("Index")]

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShopCreate()
        {
            return View();
        }



        [HttpPost]
        [Route("CreateSubmit")]
        public IActionResult CreateSubmit(ShopsL Shop)
        
        {
            if (Shop.ProductName !=null && Shop.ProductDescription !=null)
            {
                _context.Add(Shop);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(Shop);
        }


        public IActionResult ShopLebels()
        {
            var LebelList = _context.ShopLebels.ToList();

            return View();
        }

        public IActionResult LabelCreate(ShopLebel model)
        {
            _context.ShopLebels.Add(model);

            try
            {
                _context.SaveChanges();
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }

        }


    }
}
