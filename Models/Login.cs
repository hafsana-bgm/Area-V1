using System.ComponentModel.DataAnnotations;

namespace Area_v1.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool RememberMe { get; set; }


    }
}
