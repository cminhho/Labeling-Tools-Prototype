using System;
using System.Collections.Generic;
using LayoutService.Domain.Templates;
using System.Threading.Tasks;
using LayoutTemplate.Domain.Common;

namespace LayoutTemplate.Application.Templates
{
    public interface ITemplateService
    {
        Task<Template> CreateTemplateAsync(Template templateDto);
        Task<Template> UpdateTemplateAsync(Template userDto);

        Task<IReadOnlyList<Template>> GetAllTemplatesAsync();
        Task<Template> GetTemplateByIdAsync(Guid templateId);
        Task DeleteTemplateAsync(Guid templateId);

    }
}
