using LayoutTemplate.Domain.Templates;
using LayoutTemplate.Domain.TemplateTypes;

namespace LayoutTemplate.Infrastructure.Domain
{
    public interface IUnitOfWork
    {
        ITemplateRepository TemplateRepository { get; }
        ITemplateTypeRepository TemplateTypeRepository { get; }

        void Commit();
        void Roolback();
    }
}
