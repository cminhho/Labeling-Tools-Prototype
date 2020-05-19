using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LayoutService.API.Infrastructure;
using LayoutService.API.Model;
using LayoutService.API.Respotiroties;

namespace LayoutTemplate.API.Services.Implementation
{
    public class TemplateService : ITemplateService
    {
        private readonly AppDbContext _context;
        private readonly ITemplateRepository _templateRepository;

        public TemplateService(AppDbContext context, ITemplateRepository templateRepositor)
        {
            _context = context;
            _templateRepository = templateRepositor;
        }
        public async Task<Template> CreateTemplate(Template template)
        {
            //var template = new Template();
            //template.Name = templateDto.name;
            return await _templateRepository.CreateTemplate(template);
        }

        public async Task<Template> DeleteTemplateByIdAsync(Guid templateId)
        {
            return await _templateRepository.DeleteTemplateByIdAsync(templateId);
        }

        public async Task<IEnumerable<Template>> GetAllTemplates()
        {
            return await _templateRepository.GetAllAsync();
        }

        public async Task<Template> GetTemplateByIdAsync(Guid templateId)
        {
            return await _templateRepository.GetTemplateByIdAsync(templateId);
        }

        public async Task<Template> UpdateTemplate(Template templateChanges)
        {
            return await _templateRepository.UpdateTemplate(templateChanges);
        }
    }
}
