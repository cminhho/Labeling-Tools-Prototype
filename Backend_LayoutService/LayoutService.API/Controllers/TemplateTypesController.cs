using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutService.API.Model;
using LayoutTemplate.API.Services;
using LayoutTemplateType.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LayoutService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateTypesController : ControllerBase
    {
        private readonly ITemplateTypeService _templateTypeService;

        public TemplateTypesController(ITemplateTypeService TemplateTypeService)
        {
            _templateTypeService = TemplateTypeService;
        }

        // GET: api/TemplateTypes
        [HttpGet]
        public async Task<IEnumerable<TemplateType>> GetTemplateTypeItems()
        {
            return await _templateTypeService.GetAllTemplateTypes();
        }

        // GET: api/TemplateTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TemplateType>> GetTemplateType(Guid id)
        {
            return await _templateTypeService.GetTemplateTypeByIdAsync(id);
        }

        // put: api/TemplateTypes/5
        // to protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{id}")]
        public async Task<ActionResult<TemplateType>> PutTemplateType(long id, TemplateType TemplateType)
        {
            return await _templateTypeService.UpdateTemplateType(TemplateType);
        }

        // POST: api/TemplateTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TemplateType>> PostTemplateType(TemplateType TemplateType)
        {
            return await _templateTypeService.CreateTemplateType(TemplateType);
        }

        // delete: api/TemplateTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TemplateType>> deleteTemplateType(Guid id)
        {
            return await _templateTypeService.DeleteTemplateTypeByIdAsync(id);
        }
    }
}
