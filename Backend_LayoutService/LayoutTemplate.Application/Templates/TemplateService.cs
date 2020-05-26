using LayoutService.Domain.Templates;
using LayoutTemplate.Infrastructure.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LayoutTemplate.Application.Templates
{
    public class TemplateService : ITemplateService
    {
        private readonly ILogger<TemplateService> _logger;
        private IUnitOfWork _unitOfWork;

        public TemplateService(ILogger<TemplateService> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task<Template> CreateTemplateAsync(Template template)
        {
            return await _unitOfWork.TemplateRepository.AddAsync(template);
        }

        public async Task DeleteTemplateAsync(Guid templateId)
        {
            var template = await _unitOfWork.TemplateRepository.GetByIdAsync(templateId);
            await _unitOfWork.TemplateRepository.DeleteAsync(template);
        }

        public async Task<IReadOnlyList<Template>> GetAllTemplatesAsync()
        {
            return await _unitOfWork.TemplateRepository.ListAllAsync();
        }

        public async Task<Template> GetTemplateByIdAsync(Guid templateId)
        {
            return await _unitOfWork.TemplateRepository.GetByIdAsync(templateId);
        }

        public async Task<Template> UpdateTemplateAsync(Template templateChanges)
        {
            return await _unitOfWork.TemplateRepository.UpdateAsync(templateChanges);
        }
    }
}
