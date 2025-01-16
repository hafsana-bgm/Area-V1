using System.IO;
using Area_v1.Data;
using Area_v1.Migrations;
using Area_v1.Models;
using Area_v1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Area_v1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly BAreaContext _context;
        public ProductsController(BAreaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.LabelList = _context.LookUpLebels.Select(x => new SelectListItem
            {
                Value = x.LookUpLebelId.ToString(),
                Text = x.LookUpLebelName
            }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubmit(LookUpView product)
        {
            //File Upload Start


            string UniqueFileName = null;
            if (product.UploadImage != null)
            {
                //string curr = Directory.GetCurrentDirectory();
                //string folderName = "wwwroot/upload";
                //string uploadFolder = Path.Combine(curr, folderName);

                // uporerta othoba nicher jkono ekta neya zabe

                string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\upload");

                UniqueFileName = Guid.NewGuid().ToString() + "_" + product.UploadImage.FileName;

                string filepath = Path.Combine(uploadFolder, UniqueFileName);

                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);

                }
                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                    await product.UploadImage.CopyToAsync(filestream);
                }

            }

            var RealDataModel = new LookUp();

            RealDataModel.ProductName = product.ProductName;
            RealDataModel.ProductPrice = product.ProductPrice;
            RealDataModel.ProductDescription = product.ProductDescription;
            RealDataModel.ProductCatagory = product.ProductCatagory;
            RealDataModel.ProductImage = UniqueFileName;


            _context.Lookups.Add(RealDataModel);
            _context.SaveChanges();



            return RedirectToAction("Create");
        }
        //file Upload end

        public IActionResult Lebels()
        {
            var LebelList = _context.LookUpLebels.ToList();

            return View(LebelList);
        }

       
        public IActionResult LebelsCreate(LookUpLebel Datamodel)
        {
            _context.LookUpLebels.Add(Datamodel);
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
        public IActionResult Productlist()
        {
            var Product = _context.Lookups.ToList();

            return View(Product);
        }

    }
}
