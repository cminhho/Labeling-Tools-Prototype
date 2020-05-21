using LayoutService.API.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LayoutTemplate.API.Services
{
    public interface ITemplateTypeService
    {
        Task<TemplateType> CreateTemplateTypeAsync(TemplateType templateType);
        Task<TemplateType> UpdateTemplateTypeAsync(TemplateType templateType);

        Task<IEnumerable<TemplateType>> GetAllTemplateTypesAsync();
        Task<TemplateType> GetTemplateTypeByIdAsync(Guid templateTypeId);
        Task<TemplateType> DeleteTemplateTypeByIdAsync(Guid templateTypeId);

    }
}
