using System.ComponentModel.DataAnnotations;

namespace Area_v1.Models
{
    public class Register
    {
        [Key]
        public int RegisterId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
