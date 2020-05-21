using LayoutService.API.Infrastructure;
using LayoutService.API.Model;
using LayoutService.API.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LayoutService.API.Respotiroties.Implementation
{
    public class TemplateRepository : Repository<Template>, ITemplateRepository
    {
        private readonly AppDbContext _context;

        public TemplateRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Template> CreateTemplateAsync(Template template)
        {
            await _context.Templates.AddAsync(template);
            await _context.SaveChangesAsync();
            return template;
        }

        public async Task<Template> DeleteTemplateByIdAsync(Guid templateId)
        {
            Template template = await _context.Templates.FindAsync(templateId);
            if (template != null) 
            {
                _context.Templates.Remove(template);
                await _context.SaveChangesAsync();
            }
            return template;
        }

        public async Task<IEnumerable<Template>> GetAllAsync()
        {
            return await _context.Templates.ToListAsync();
        }

        public async Task<Template> GetTemplateByIdAsync(Guid templateId)
        {
            return await _context.Templates.FindAsync(templateId);
        }

        public async Task<Template> UpdateTemplateAsync(Template employeeChanges)
        {
            var employee = this._context.Templates.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return employeeChanges;
        }
    }
}
