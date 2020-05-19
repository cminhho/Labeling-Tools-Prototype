using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutService.API.Model;
using LayoutTemplate.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LayoutService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {
        private readonly ITemplateService _templateService;

        public TemplatesController(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        // GET: api/Templates
        [HttpGet]
        public async Task<IEnumerable<Template>> GetTemplateItems()
        {
            return await _templateService.GetAllTemplates();
        }

        // GET: api/Templates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Template>> GetTemplate(Guid id)
        {
            return await _templateService.GetTemplateByIdAsync(id);
        }

        // put: api/templates/5
        // to protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{id}")]
        public async Task<ActionResult<Template>> PutTemplate(long id, Template template)
        {
            return await _templateService.UpdateTemplate(template);
        }

        // POST: api/Templates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Template>> PostTemplate(Template template)
        {
            return await _templateService.CreateTemplate(template);
        }

        // delete: api/templates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Template>> deletetemplate(Guid id)
        {
            return await _templateService.DelteTemplateByIdAsync(id);
        }
    }
}
