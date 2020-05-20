using LayoutService.API.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LayoutService.API.Respotiroties
{
    public interface ITemplateTypeRepository
    {
        Task<TemplateType> CreateTemplateType(TemplateType TemplateType);
        Task<TemplateType> UpdateTemplateType(TemplateType TemplateType);
        Task<IEnumerable<TemplateType>> GetAllAsync();
        Task<TemplateType> GetTemplateTypeByIdAsync(Guid TemplateTypeId);
        Task<TemplateType> DeleteTemplateTypeByIdAsync(Guid TemplateTypeId);
    }
}
