using LayoutService.Domain.Templates;
using Microsoft.EntityFrameworkCore;

namespace LayoutService.API.Infrastructure
{
    public class EFDBContext: DbContext
    {
        public EFDBContext()
        {

        }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {

        }

        public DbSet<Template> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PDFInboundAutomation-3;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
