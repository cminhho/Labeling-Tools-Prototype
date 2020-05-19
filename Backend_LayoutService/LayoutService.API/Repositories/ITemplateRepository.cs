using LayoutService.API.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LayoutService.API.Respotiroties
{
    public interface ITemplateRepository
    {
        Task<Template> CreateTemplate(Template template);
        Task<Template> UpdateTemplate(Template template);
        Task<IEnumerable<Template>> GetAllAsync();
        Task<Template> GetTemplateByIdAsync(Guid templateId);
        void DeleteTemplateByIdAsync(Guid templateId);
    }
}
