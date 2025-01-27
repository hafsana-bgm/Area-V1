using Area_v1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Area_v1.Data
{
    public class BAreaContext(DbContextOptions<BAreaContext> options) : IdentityDbContext(options)
    {


        public required DbSet<ShopsL> Shops { get; set; }
        public required DbSet<ShopLebel> ShopLebels { get; set; }
        public required DbSet<Models.LookUp> Lookups { get; set; }
        public required DbSet<Models.LookUpLebel> LookUpLebels { get; set; }
        public required DbSet<Product> Product { get; set; }
        public required DbSet<Labels> Labels { get; set; }
        public required DbSet<Login> Logins { get; set; }
        public required DbSet<Register> Registers { get; set; }


    }
}
