using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LayoutService.API.Infrastructure;
using LayoutService.API.Model;

namespace LayoutTemplate.API.Service
{
    public class TemplateService : ITemplateService
    {
        private readonly TemplateContext _context;
        private readonly ITemplateRepository _templateRepository;

        public TemplateService(TemplateContext context, ITemplateRepository templateRepositor)
        {
            _context = context;
            _templateRepository = templateRepositor;
        }
        public async Task CreateTemplate(TemplateDto templateDto)
        {
            var template = new Template();
            template.Name = templateDto.name;

            await _templateRepository.CreateTemplate(template);
        }

        public Task<Template> DelteTemplateByIdAsync(Guid templateId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Template>> GetAllTemplates()
        {
            return await _templateRepository.GetAllAsync();
        }

        public async Task<Template> GetTemplateByIdAsync(Guid templateId)
        { 
            return await _templateRepository.GetTemplateByIdAsync(templateId);
        }

        public Task<Template> UpdateTemplate(TemplateDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
