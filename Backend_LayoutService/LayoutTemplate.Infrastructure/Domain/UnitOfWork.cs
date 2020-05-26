

using LayoutService.Infrastructure.Database;
using LayoutTemplate.Domain.Templates;
using LayoutTemplate.Domain.TemplateTypes;
using LayoutTemplate.Infrastructure.Domain.Templates;
using LayoutTemplate.Infrastructure.Domain.TemplateTypes;

namespace LayoutTemplate.Infrastructure.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _dbContext;
        private ITemplateRepository _templateRepository;
        private ITemplateTypeRepository _templateTypeRepository;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ITemplateRepository TemplateRepository
        {
            get
            {
                if (_templateRepository == null)
                {
                    _templateRepository = new TemplateRepository(_dbContext);
                }
                return _templateRepository;
            }
        }

        public ITemplateTypeRepository TemplateTypeRepository
        {
            get
            {
                if (_templateTypeRepository == null)
                {
                    _templateTypeRepository = new TemplateTypeRepository(_dbContext);
                }
                return _templateTypeRepository;
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Roolback()
        {
            _dbContext.Dispose();
        }
    }
}
