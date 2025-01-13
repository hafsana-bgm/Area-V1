using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Area_v1.Areas.Admin.Data
{
    public class BAreaContext(DbContextOptions<BAreaContext> options) : IdentityDbContext(options)
    {
       

        public required DbSet<Area_v1.Areas.Admin.DataModel.ShopsL> Shops { get; set; }
        public required DbSet<Area_v1.Areas.Admin.DataModel.ShopLebel> ShopLebels { get; set; }
        public required DbSet<Area_v1.Models.LookUp> Lookups { get; set; }
        public required DbSet<Area_v1.Models.LookUpLebel> LookUpLebels { get; set; }
       
    }
}
