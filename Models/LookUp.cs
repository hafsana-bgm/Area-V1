using System.ComponentModel.DataAnnotations;

namespace Area_v1.Models
{
    public class LookUp
    { 
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductPrice { get; set; }
        public string? ProductImage { get; set; }
        public int LookUpLebelId { get; set; }
        public int ProductCount { get; set; }
        public string? ProductCatagory { get; set; }
        public bool IsActive { get; set; }
    
    }
    public class LookUpLebel
    {
        [Key]

        public int LookUpLebelId { get; set; }
        public String? LookUpLebelName { get; set; }
    }

}
