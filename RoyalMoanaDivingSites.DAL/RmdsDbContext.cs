using Microsoft.EntityFrameworkCore;
using RoyalMoanaDivingSites.DAL.Configurations;
using RoyalMoanaDivingSites.DAL.Entities;

namespace RoyalMoanaDivingSites.DAL
{
    public class RmdsDbContext : DbContext
    {
        public RmdsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DivingSite> DivingSites { get; set; }
        public DbSet<Arm> Arms { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Level> Levels { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfiguration(new DivingSiteConfig());
            mb.ApplyConfiguration(new ArmConfig());
            mb.ApplyConfiguration(new ImageConfig());
            mb.ApplyConfiguration(new LevelConfig());
        }
    }
}
