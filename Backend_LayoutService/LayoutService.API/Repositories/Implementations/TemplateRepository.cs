using LayoutService.API.Infrastructure;
using LayoutService.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LayoutService.API.Respotiroties.Implementation
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly AppDbContext _context;

        public TemplateRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Template> CreateTemplate(Template template)
        {
            this._context.Templates.Add(template);
            this._context.SaveChanges();
            return template;
        }

        public void DeleteTemplateByIdAsync(Guid templateId)
        {
            Template template = this._context.Templates.Find(templateId);
            if (template != null) 
            {
                this._context.Templates.Remove(template);
            }
        }

        public async Task<IEnumerable<Template>> GetAllAsync()
        {
            return await _context.Templates.ToListAsync();
        }

        public async Task<Template> GetTemplateByIdAsync(Guid templateId)
        {
            return this._context.Templates.Find(templateId);
        }

        public async Task<Template> UpdateTemplate(Template employeeChanges)
        {
            var employee = this._context.Templates.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this._context.SaveChanges();
            return employeeChanges;
        }
    }
}
