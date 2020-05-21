using LayoutService.API.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace LayoutTemplate.API.Services
{
    public interface ITemplateService
    {
        Task<Template> CreateTemplateAsync(Template templateDto);
        Task<Template> UpdateTemplateAsync(Template userDto);

        Task<IEnumerable<Template>> GetAllTemplatesAsync();
        Task<Template> GetTemplateByIdAsync(Guid templateId);
        Task<Template> DeleteTemplateByIdAsync(Guid templateId);

    }
}
