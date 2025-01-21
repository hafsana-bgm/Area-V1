using Area_v1.Data;
using Area_v1.Models;
using Area_v1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Area_v1.Controllers
{
    public class ShopController : Controller
    {
        private readonly BAreaContext _context;
        public ShopController(BAreaContext context)
        {
            _context = context;
        }

         public IActionResult ShopCreate()
         {
            ViewBag.LabelList = _context.Labels.Select(x => new SelectListItem
            {
                Value = x.LableId.ToString(),
                Text = x.LabelName
            }).ToList();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ShopCreate(ShopVM product)
        {
            String UniqueFileName = null;
            if (product.UploadImage != null)
            {
                String UploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\UploadImage");

                UniqueFileName = Guid.NewGuid().ToString() + "_" + product.UploadImage.FileName;

                String filepath = Path.Combine(UploadFolder, UniqueFileName);

                if (!Directory.Exists(UploadFolder))
                {
                    Directory.CreateDirectory(UploadFolder);

                }
                using(var fillestream = new FileStream(filepath, FileMode.Create))
                {
                    await product.UploadImage.CopyToAsync(fillestream);
                }
            }

            var RealDataModel = new Product();

            RealDataModel.Name = product.Name;
            RealDataModel.Description = product.Description;
            RealDataModel.Price = product.Price;
            RealDataModel.Category = product.Category;
            RealDataModel.Image = UniqueFileName;

            _context.Product.Add(RealDataModel);
            _context.SaveChanges();



            ViewBag.LabelList = _context.Labels.Select(x => new SelectListItem
            {
                Value = x.LableId.ToString(),
                Text = x.LabelName
            }).ToList();


            return RedirectToAction("ShopCreate");
        }

        public IActionResult ShopList()
        {
            var product = _context.Product.ToList();

            return View(product);
        }

        public IActionResult ShopEdit(int? id)
        {
            if (id == null)
          
            return NotFound();
            var ProductData = _context.Product.FirstOrDefault(x => x.ProductId == id);

            return View(ProductData);
        }
        [HttpPost]
        public async Task<IActionResult> ShopEdit(ShopVM product)
        {
            String UniqueFileName = null;
            if (product.UploadImage != null)
            {
                String UploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\UploadImage");

                UniqueFileName = Guid.NewGuid().ToString() + "_" + product.UploadImage.FileName;

                String filepath = Path.Combine(UploadFolder, UniqueFileName);

                if (!Directory.Exists(UploadFolder))
                {
                    Directory.CreateDirectory(UploadFolder);

                }
                using (var fillestream = new FileStream(filepath, FileMode.Create))
                {
                    await product.UploadImage.CopyToAsync(fillestream);
                }
            }

            var RealDataModel = new Product();

            RealDataModel.ProductId = product.ProductId;
            RealDataModel.Name = product.Name;
            RealDataModel.Description = product.Description;
            RealDataModel.Price = product.Price;
            RealDataModel.Category = product.Category;
            RealDataModel.Image = UniqueFileName;

            _context.Product.Update(RealDataModel);

            _context.SaveChanges();

            ViewBag.LabelList = _context.Labels.Select(x => new SelectListItem
            {
                Value = x.LableId.ToString(),
                Text = x.LabelName
            }).ToList();

            return RedirectToAction("ShopList");
        }

        public IActionResult ShopDelete(int? id)
        {
            if(id == null)
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


            return RedirectToAction("ShopList");
        }
        public IActionResult LebelList()
        {
            var LebelList = _context.Labels.ToList();

            return View(LebelList);
           
        }

        public IActionResult LebelsCreate(Labels Datamodel)
        {
            _context.Labels.Add(Datamodel);
            try
            {

                _context.SaveChanges();

                var result = _context.Labels.ToList();

                return Json(new { success = true, newData = result });
            }
            catch (Exception)

            {
                return Json(false);
            }


        }

        public IActionResult LabelDelete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Labels.FirstOrDefault(x => x.LableId == id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("LebelList");

        }

    }
}
