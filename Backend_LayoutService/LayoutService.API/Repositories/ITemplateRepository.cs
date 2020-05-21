using LayoutService.API.Model;
using LayoutService.API.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LayoutService.API.Respotiroties
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
