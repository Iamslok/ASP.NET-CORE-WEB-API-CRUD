using Microsoft.EntityFrameworkCore;
using WEB_API.Models;

namespace WEB_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<UserDetails> Users { get; set; }
    }
}
