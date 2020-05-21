using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LayoutService.API.Infrastructure;
using LayoutService.API.Model;

namespace LayoutTemplate.API.Services.Implementation
{
    public class TemplateService : ITemplateService
    {
        private UnitOfWork _context;

        public TemplateService(UnitOfWork _context)
        {
            this._context = _context;
        }
        public async Task<Template> CreateTemplateAsync(Template template)
        {
            return await _context.TemplateRepository.CreateTemplateAsync(template);
        }

        public async Task<Template> DeleteTemplateByIdAsync(Guid templateId)
        {
            return await _context.TemplateRepository.DeleteTemplateByIdAsync(templateId);
        }

        public async Task<IEnumerable<Template>> GetAllTemplatesAsync()
        {
            return await _context.TemplateRepository.GetAllAsync();
        }

        public async Task<Template> GetTemplateByIdAsync(Guid templateId)
        {
            return await _context.TemplateRepository.GetTemplateByIdAsync(templateId);
        }

        public async Task<Template> UpdateTemplateAsync(Template templateChanges)
        {
            return await _context.TemplateRepository.UpdateTemplateAsync(templateChanges);
        }
    }
}
