using BeatleBug.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BeatleBug.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Models.ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Comment> Comments { get; set; }
}
}
