using LayoutService.Domain.Templates;
using LayoutService.Infrastructure.Database;
using LayoutTemplate.Domain.Templates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LayoutTemplate.Infrastructure.Domain
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly TemplateContext _context;

        public TemplateRepository(TemplateContext context)
        {
            _context = context;
        }
        public async Task CreateTemplate(Template template)
        {
            await this._context.Templates.AddAsync(template);
        }

        public Task<Template> DelteTemplateByIdAsync(Guid templateId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Template>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Template> GetTemplateByIdAsync(Guid templateId)
        {
            throw new NotImplementedException();
        }

        public Task<Template> UpdateTemplate(Template userDto)
        {
            throw new NotImplementedException();
        }
    }
}
