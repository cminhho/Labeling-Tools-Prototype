using LayoutTemplate.Domain.TemplateTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LayoutTemplate.Domain.TemplateTypes
{
    public interface ITemplateTypeRepository
    {
        Task<TemplateType> CreateTemplateTypeAsync(TemplateType TemplateType);
        Task<TemplateType> UpdateTemplateTypeAsync(TemplateType TemplateType);
        Task<IEnumerable<TemplateType>> GetAllAsync();
        Task<TemplateType> GetTemplateTypeByIdAsync(Guid TemplateTypeId);
        Task<TemplateType> DeleteTemplateTypeByIdAsync(Guid TemplateTypeId);
    }
}
