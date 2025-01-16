using System.Reflection.Emit;
using Area_v1.Areas.Admin.Data;
using Area_v1.Areas.Admin.DataModel;
using Area_v1.Areas.ViewModel;
using Area_v1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.LabelList = _context.ShopLebels.Select(x => new SelectListItem
            {
                Value = x.ShopLebelId.ToString(),
                Text = x.LebelName
            }).ToList();
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CreateSubmit(ShopVM product)
        {
            //file upload start
            string uniqueFileName = null;
            if (product.UploadImage != null)
            {

                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + product.UploadImage.FileName;

                string filepath = Path.Combine(uploadsFolder, uniqueFileName);

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                using (var filestrem = new FileStream(filepath, FileMode.Create))
                {
                    await product.UploadImage.CopyToAsync(filestrem);
                }

            }
            //file upload end

            var RealDataModel = new Product();

            RealDataModel.Name= product.ProductName;          
            RealDataModel.Description = product.ProductDescription;
            RealDataModel.Category = product.ProductCatagory;
            RealDataModel.Image = uniqueFileName;

            _context.Product.Add(RealDataModel);
            _context.SaveChanges();

            return View("ShopCreate");
        }

        public IActionResult ShopList()
        {
            var Product = _context.Shops.ToList();

            return View(Product);
           
        }

        public IActionResult ShopLebels()
        {
            var LebelList = _context.ShopLebels.ToList();

            return View(LebelList);
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
