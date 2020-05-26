using LayoutService.Domain.Templates;
using LayoutTemplate.Domain.TemplateTypes;
using Microsoft.EntityFrameworkCore;

namespace LayoutService.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Template> Templates { get; set; }
        public DbSet<TemplateType> TemplateTypes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

    }
}
