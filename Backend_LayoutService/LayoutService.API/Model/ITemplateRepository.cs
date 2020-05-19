using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LayoutService.API.Model
{
    public interface ITemplateRepository
    {
        Task CreateTemplate(Template template);
        Task<Template> UpdateTemplate(Template userDto);
        Task<List<Template>> GetAllAsync();
        Task<Template> GetTemplateByIdAsync(Guid templateId);
        Task<Template> DelteTemplateByIdAsync(Guid templateId);
    }
}
