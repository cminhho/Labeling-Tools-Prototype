using LayoutService.API.Model;
using Microsoft.EntityFrameworkCore;

namespace LayoutService.API.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Template> Templates { get; set; }
    }
}
