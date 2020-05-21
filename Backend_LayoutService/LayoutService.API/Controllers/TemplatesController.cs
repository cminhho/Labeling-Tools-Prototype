using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LayoutService.API.Model;
using LayoutTemplate.API.Services;
using Microsoft.AspNetCore.Mvc;


namespace LayoutService.Controllers
{
    [Route("api")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {
        private readonly ITemplateService _templateService;

        public TemplatesController(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        // GET: api/Templates
        [HttpGet("templates")]
        public async Task<IEnumerable<Template>> GetTemplateItems()
        {
            return await _templateService.GetAllTemplatesAsync();
        }

        // GET: api/Templates/5
        [HttpGet("templates/{id}")]
        public async Task<ActionResult<Template>> GetTemplateAsync(Guid id)
        {
            return await _templateService.GetTemplateByIdAsync(id);
        }

        // put: api/templates/5
        // to protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("templates/{id}")]
        public async Task<ActionResult<Template>> PutTemplateAsync(long id, Template template)
        {
            return await _templateService.UpdateTemplateAsync(template);
        }

        // POST: api/Templates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("templates")]
        public async Task<ActionResult<Template>> PostTemplateAsync(Template template)
        {
            return await _templateService.CreateTemplateAsync(template);
        }

        // delete: api/templates/5
        [HttpDelete("templates/{id}")]
        public async Task<ActionResult<Template>> DeleteTemplateAsync(Guid id)
        {
            return await _templateService.DeleteTemplateByIdAsync(id);
        }
    }
}
