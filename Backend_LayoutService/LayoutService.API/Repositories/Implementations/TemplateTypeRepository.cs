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
        public async Task<TemplateType> CreateTemplateType(TemplateType TemplateType)
        {
            this._context.TemplateTypes.Add(TemplateType);
            this._context.SaveChanges();
            return TemplateType;
        }

        public async Task<TemplateType> DeleteTemplateTypeByIdAsync(Guid TemplateTypeId)
        {
            TemplateType TemplateType = this._context.TemplateTypes.Find(TemplateTypeId);
            if (TemplateType != null)
            {
                this._context.TemplateTypes.Remove(TemplateType);
            }
            return TemplateType;
        }

        public async Task<IEnumerable<TemplateType>> GetAllAsync()
        {
            return await _context.TemplateTypes.ToListAsync();
        }

        public async Task<TemplateType> GetTemplateTypeByIdAsync(Guid TemplateTypeId)
        {
            return this._context.TemplateTypes.Find(TemplateTypeId);
        }

        public async Task<TemplateType> UpdateTemplateType(TemplateType employeeChanges)
        {
            var employee = this._context.TemplateTypes.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this._context.SaveChanges();
            return employeeChanges;
        }
    }
}
