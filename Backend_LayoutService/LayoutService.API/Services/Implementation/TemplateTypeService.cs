﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LayoutService.API.Infrastructure;
using LayoutService.API.Model;
using LayoutTemplate.API.Services;

namespace LayoutTemplateType.API.Services.Implementation
{
    public class TemplateTypeService : ITemplateTypeService
    {
        private UnitOfWork _context;

        public TemplateTypeService(UnitOfWork context)
        {
            this._context = context;
        }
        public async Task<TemplateType> CreateTemplateTypeAsync(TemplateType TemplateType)
        {
            return await _context.TemplateTypeRepository.CreateTemplateTypeAsync(TemplateType);
        }

        public async Task<TemplateType> DeleteTemplateTypeByIdAsync(Guid TemplateTypeId)
        {
            return await _context.TemplateTypeRepository.DeleteTemplateTypeByIdAsync(TemplateTypeId);
        }

        public async Task<IEnumerable<TemplateType>> GetAllTemplateTypesAsync()
        {
            return await _context.TemplateTypeRepository.GetAllAsync();
        }

        public async Task<TemplateType> GetTemplateTypeByIdAsync(Guid TemplateTypeId)
        {
            return await _context.TemplateTypeRepository.GetTemplateTypeByIdAsync(TemplateTypeId);
        }

        public async Task<TemplateType> UpdateTemplateTypeAsync(TemplateType TemplateTypeChanges)
        {
            return await _context.TemplateTypeRepository.UpdateTemplateTypeAsync(TemplateTypeChanges);
        }
    }
}
