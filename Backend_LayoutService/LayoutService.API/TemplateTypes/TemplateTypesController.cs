using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LayoutTemplate.Application.TemplateTypes;
using LayoutTemplate.Domain.TemplateTypes;
using Microsoft.AspNetCore.Mvc;

namespace LayoutService.API.TemplateTypes
{
    [Route("api")]
    [ApiController]
    public class TemplateTypesController : ControllerBase
    {
        private readonly ITemplateTypeService _templateTypeService;

        public TemplateTypesController(ITemplateTypeService TemplateTypeService)
        {
            _templateTypeService = TemplateTypeService;
        }

        // GET: api/TemplateTypes
        [HttpGet("templatetype")]
        public async Task<IEnumerable<TemplateType>> GetTemplateTypeItemsAsync()
        {
            return await _templateTypeService.GetAllTemplateTypesAsync();
        }

        // GET: api/TemplateTypes/5
        [HttpGet("templatetype/{id}")]
        public async Task<ActionResult<TemplateType>> GetTemplateTypeAsync(Guid id)
        {
            return await _templateTypeService.GetTemplateTypeByIdAsync(id);
        }

        // put: api/TemplateTypes/5
        // to protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("templatetype/{id}")]
        public async Task<ActionResult<TemplateType>> PutTemplateTypeAsync(long id, TemplateType TemplateType)
        {
            return await _templateTypeService.UpdateTemplateTypeAsync(TemplateType);
        }

        // POST: api/TemplateTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("templatetype")]
        public async Task<ActionResult<TemplateType>> PostTemplateTypeAsync(TemplateType TemplateType)
        {
            return await _templateTypeService.CreateTemplateTypeAsync(TemplateType);
        }

        // delete: api/TemplateTypes/5
        [HttpDelete("templatetype/{id}")]
        public async Task<ActionResult<TemplateType>> DeleteTemplateTypeAsync(Guid id)
        {
            return await _templateTypeService.DeleteTemplateTypeByIdAsync(id);
        }
    }
}
