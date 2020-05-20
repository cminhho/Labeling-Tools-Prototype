using LayoutService.API.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LayoutTemplate.API.Services
{
    public interface ITemplateTypeService
    {
        Task<TemplateType> CreateTemplateType(TemplateType templateType);
        Task<TemplateType> UpdateTemplateType(TemplateType templateType);

        Task<IEnumerable<TemplateType>> GetAllTemplateTypes();
        Task<TemplateType> GetTemplateTypeByIdAsync(Guid templateTypeId);
        Task<TemplateType> DeleteTemplateTypeByIdAsync(Guid templateTypeId);

    }
}
