using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulgarianTechGear.Data
{
    using Models;

    public class BulgarianTechGearDbContext : IdentityDbContext
    {
        public BulgarianTechGearDbContext(DbContextOptions<BulgarianTechGearDbContext> options)
            : base(options)
        {
        }

        public DbSet<MobilePhone> MobilePhones { get; set; } = null!;
        public DbSet<MobilePhoneBrand> MobilePhoneBrands { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MobilePhone>().HasKey(x => new {x.BrandId, x.Id});
            base.OnModelCreating(builder);
        }
    }
}