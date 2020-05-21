using LayoutService.API.Respotiroties;

namespace LayoutService.API.Infrastructure
{
    public interface IUnitOfWork
    {
        //ITemplateRepository TemplateRepository { get; }

        //ITemplateTypeRepository TemplateTypeRepository { get; }

        int SaveChanges();
    }
}
