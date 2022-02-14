using K205Agency.Models;
using Microsoft.EntityFrameworkCore;

namespace K205Agency.Data
{
    public class AgencyDbContext : DbContext
    {
        public AgencyDbContext(DbContextOptions<AgencyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Masthead> Mastheads { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
    }
}
