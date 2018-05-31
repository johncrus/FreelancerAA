using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FreelancerData.Models;

namespace FreelancerData
{
    public class FreelancerContext : IdentityDbContext<ApplicationUser>
    {
        public FreelancerContext(DbContextOptions<FreelancerContext> options) : base(options) { }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<JobAppliance> JobAppliances { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
