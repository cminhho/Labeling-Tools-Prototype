using LayoutService.Domain.Templates;
using LayoutTemplate.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LayoutTemplate.Domain.Templates
{
    public interface ITemplateRepository : IRepository<Template>
    {
        Task<Template> CreateTemplateAsync(Template template);
        Task<Template> UpdateTemplateAsync(Template template);
        Task<IEnumerable<Template>> GetAllAsync();
        Task<Template> GetTemplateByIdAsync(Guid templateId);
        Task<Template> DeleteTemplateByIdAsync(Guid templateId);
    }
}
