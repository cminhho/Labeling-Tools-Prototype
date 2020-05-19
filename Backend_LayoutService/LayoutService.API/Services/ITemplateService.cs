using LayoutService.API.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace LayoutTemplate.API.Services
{
    public interface ITemplateService
    {
        Task<Template> CreateTemplate(Template templateDto);
        Task<Template> UpdateTemplate(Template userDto);

        Task<IEnumerable<Template>> GetAllTemplates();
        Task<Template> GetTemplateByIdAsync(Guid templateId);
        Task<Template> DelteTemplateByIdAsync(Guid templateId);

    }
}
