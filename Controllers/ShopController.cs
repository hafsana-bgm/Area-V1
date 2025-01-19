using Area_v1.Data;
using Area_v1.Models;
using Microsoft.AspNetCore.Mvc;

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

            return View();
         }
        [HttpPost]
        public async Task<IActionResult> ShopCreate(Product product)
        {
            String UniqueFileName = null;
            if (product.Image != null)
            {
                String UploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot.uploadimg");

             

                String filepath = Path.Combine(UploadFolder, UniqueFileName);

            }


            return View(product);
        }
    }
}
