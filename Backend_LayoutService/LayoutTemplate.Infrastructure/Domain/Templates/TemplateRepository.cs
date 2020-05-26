using LayoutService.Domain.Templates;
using LayoutService.Infrastructure.Database;
using LayoutTemplate.Domain.Templates;

namespace LayoutTemplate.Infrastructure.Domain.Templates
{
    public class TemplateRepository : EfRepository<Template>, ITemplateRepository
    {
        private readonly AppDbContext dbContext;

        public TemplateRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
       
    }
}
