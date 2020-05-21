using LayoutService.API.Respotiroties;

namespace LayoutService.API.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
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
