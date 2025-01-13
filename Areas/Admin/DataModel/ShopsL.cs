using System.ComponentModel.DataAnnotations;

namespace Area_v1.Areas.Admin.DataModel
{
    public class ShopsL
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductPrice { get; set; }
        public string? ProductImage { get; set; }
        public int LebelId { get; set; }
        public int ProductCount { get; set; }
        public string? ProductCatagory { get; set; }
        public bool IsActive { get; set; }
    }

    public class ShopLebel
    {
        [Key]

        public int ShopLebelId { get; set; }
        public String? LebelName { get; set; }
    }
}
    