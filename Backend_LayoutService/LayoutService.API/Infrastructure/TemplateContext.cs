using LayoutService.API.Model;
using Microsoft.EntityFrameworkCore;

namespace LayoutService.API.Infrastructure
{
    public class TemplateContext : DbContext
    {
        public TemplateContext(DbContextOptions<TemplateContext> options)
            : base(options)
        {
        }

        public DbSet<Template> Templates { get; set; }
    }
}
