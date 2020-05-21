using System;
using System.Collections.Generic;
using LayoutService.Domain.Templates;
using System.Threading.Tasks;


namespace LayoutTemplate.Application.Templates
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
