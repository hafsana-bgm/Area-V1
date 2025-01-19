using System.ComponentModel.DataAnnotations;

namespace Area_v1.ViewModel
{
    public class ShopVM
    {
        [Key]
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public int LableId { get; set; }
        public bool IsActive { get; set; }
        public string? Category { get; set; }
        public IFormFile? UploadImage { get; set; }

    }
}
