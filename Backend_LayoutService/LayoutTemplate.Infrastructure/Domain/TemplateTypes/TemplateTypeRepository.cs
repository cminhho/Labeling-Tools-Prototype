using LayoutService.Infrastructure.Database;
using LayoutTemplate.Domain.TemplateTypes;

namespace LayoutTemplate.Infrastructure.Domain.TemplateTypes
{
    public class TemplateTypeRepository : EfRepository<TemplateType>, ITemplateTypeRepository
    {
        private readonly AppDbContext dbContext;

        public TemplateTypeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
       
    }
}
