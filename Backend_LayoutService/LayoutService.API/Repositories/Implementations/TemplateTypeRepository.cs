using LayoutService.API.Infrastructure;
using LayoutService.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LayoutService.API.Respotiroties.Implementation
{
    public class TemplateTypeRepository : ITemplateTypeRepository
    {
        private readonly AppDbContext _context;

        public TemplateTypeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<TemplateType> CreateTemplateTypeAsync(TemplateType TemplateType)
        {
            await _context.TemplateTypes.AddAsync(TemplateType);
            await _context.SaveChangesAsync();
            return TemplateType;
        }

        public async Task<TemplateType> DeleteTemplateTypeByIdAsync(Guid TemplateTypeId)
        {
            TemplateType TemplateType = await _context.TemplateTypes.FindAsync(TemplateTypeId);
            if (TemplateType != null)
            {
                _context.TemplateTypes.Remove(TemplateType);
            }
            return TemplateType;
        }

        public async Task<IEnumerable<TemplateType>> GetAllAsync()
        {
            return await _context.TemplateTypes.ToListAsync();
        }

        public async Task<TemplateType> GetTemplateTypeByIdAsync(Guid TemplateTypeId)
        {
            return await _context.TemplateTypes.FindAsync(TemplateTypeId);
        }

        public async Task<TemplateType> UpdateTemplateTypeAsync(TemplateType employeeChanges)
        {
            var employee = _context.TemplateTypes.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return employeeChanges;
        }
    }
}
