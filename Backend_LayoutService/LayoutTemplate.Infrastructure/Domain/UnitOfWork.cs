

using LayoutService.Infrastructure.Database;
using LayoutTemplate.Domain.Templates;
using LayoutTemplate.Domain.TemplateTypes;

namespace LayoutTemplate.Infrastructure.Domain
{
    public class UnitOfWork
    {
        private AppDbContext db;
        public ITemplateRepository TemplateRepository;
        public ITemplateTypeRepository TemplateTypeRepository;
        public UnitOfWork(AppDbContext db, ITemplateRepository TemplateRepository, ITemplateTypeRepository TemplateTypeRepository)
        {
            this.db = db;
            this.TemplateRepository = TemplateRepository;
            this.TemplateTypeRepository = TemplateTypeRepository;
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}
