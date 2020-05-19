using LayoutService.Domain.Templates;
using Microsoft.EntityFrameworkCore;

namespace LayoutService.Infrastructure.Database
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
