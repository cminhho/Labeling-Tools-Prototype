using LayoutService.API.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace LayoutTemplate.API.Service
{
    public interface ITemplateService
    {
        Task CreateTemplate(TemplateDto templateDto);
        //Task<Template> UpdateTemplate(TemplateDto userDto);

        Task<List<Template>> GetAllTemplates();
        //Task<Template> GetTemplateByIdAsync(Guid templateId);
        //Task<Template> DelteTemplateByIdAsync(Guid templateId);

    }
}
