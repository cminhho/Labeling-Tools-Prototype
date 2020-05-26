using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LayoutTemplate.Domain.TemplateTypes;
using LayoutTemplate.Infrastructure.Domain;

namespace LayoutTemplate.Application.TemplateTypes
{
    public class TemplateTypeService : ITemplateTypeService
    {
        private IUnitOfWork _unitOfWork;

        public TemplateTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TemplateType> CreateTemplateTypeAsync(TemplateType TemplateType)
        {
            return await _unitOfWork.TemplateTypeRepository.AddAsync(TemplateType);
        }

        public async Task DeleteTemplateTypeAsync(Guid TemplateTypeId)
        {
            var templateType = await _unitOfWork.TemplateTypeRepository.GetByIdAsync(TemplateTypeId);
            await _unitOfWork.TemplateTypeRepository.DeleteAsync(templateType);
        }

        public async Task<IEnumerable<TemplateType>> GetAllTemplateTypesAsync()
        {
            return await _unitOfWork.TemplateTypeRepository.ListAllAsync();
        }

        public async Task<TemplateType> GetTemplateTypeByIdAsync(Guid TemplateTypeId)
        {
            return await _unitOfWork.TemplateTypeRepository.GetByIdAsync(TemplateTypeId);
        }

        public async Task<TemplateType> UpdateTemplateTypeAsync(TemplateType TemplateTypeChanges)
        {
            return await _unitOfWork.TemplateTypeRepository.UpdateAsync(TemplateTypeChanges);
        }
    }
}
