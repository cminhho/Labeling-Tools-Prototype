using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LayoutService.API.Infrastructure;
using LayoutService.API.Model;
using LayoutService.API.Respotiroties;
using LayoutTemplate.API.Services;

namespace LayoutTemplateType.API.Services.Implementation
{
    public class TemplateTypeService : ITemplateTypeService
    {
        private readonly ITemplateTypeRepository _TemplateTypeRepository;

        public TemplateTypeService(ITemplateTypeRepository TemplateTypeRepositor)
        {
            _TemplateTypeRepository = TemplateTypeRepositor;
        }
        public async Task<TemplateType> CreateTemplateType(TemplateType TemplateType)
        {
            //var TemplateType = new TemplateType();
            //TemplateType.Name = TemplateTypeDto.name;
            return await _TemplateTypeRepository.CreateTemplateType(TemplateType);
        }

        public async Task<TemplateType> DeleteTemplateTypeByIdAsync(Guid TemplateTypeId)
        {
            return await _TemplateTypeRepository.DeleteTemplateTypeByIdAsync(TemplateTypeId);
        }

        public async Task<IEnumerable<TemplateType>> GetAllTemplateTypes()
        {
            return await _TemplateTypeRepository.GetAllAsync();
        }

        public async Task<TemplateType> GetTemplateTypeByIdAsync(Guid TemplateTypeId)
        {
            return await _TemplateTypeRepository.GetTemplateTypeByIdAsync(TemplateTypeId);
        }

        public async Task<TemplateType> UpdateTemplateType(TemplateType TemplateTypeChanges)
        {
            return await _TemplateTypeRepository.UpdateTemplateType(TemplateTypeChanges);
        }
    }
}
