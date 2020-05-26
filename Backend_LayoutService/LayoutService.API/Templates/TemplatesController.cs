using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using LayoutService.API.Common;
using LayoutService.Domain.Templates;
using LayoutTemplate.Application.Templates;
using LayoutTemplate.Domain.Common;
using Microsoft.AspNetCore.Mvc;

// SearchParams.cs
public class PagingParams
{
    [Required]
    public int PageNo { get; set; }

    public int PageSize { get; set; }
}

namespace LayoutService.API.Templates
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

        /// <summary>
        /// Creates an item.
        /// </summary>
        /// <param name="template">
        ///     The template.
        /// </param>
        /// <returns>
        ///     An asynchronous result that yields the create.
        /// </returns>   
        [HttpPost("templates")]
        [ProducesResponseType(typeof(Template), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Template>> PostTemplateAsync([FromBody]Template template)
        {
            return await _templateService.CreateTemplateAsync(template);
        }

        /// <summary>
        /// Gets all items
        /// </summary>
        [HttpGet("templates")]
        [ProducesResponseType(typeof(IEnumerable<Template>), 200)]
        public async Task<IReadOnlyList<Template>> GetTemplateItems()
        {
            return await _templateService.GetAllTemplatesAsync();
        }

        /// <summary>
        /// Gets a specific item by unique id
        /// </summary>
        [HttpGet("templates/{id}")]
        public async Task<IActionResult> GetTemplateAsync([FromRoute]Guid id)
        {
            var template = await _templateService.GetTemplateByIdAsync(id);
            return ActionResultUtil.WrapOrNotFound(template);
        }

        /// <summary>
        /// Updates a specific item.
        /// </summary>
        [HttpPut("templates/{id}")]
        public async Task<ActionResult<Template>> PutTemplateAsync([FromRoute]Guid id, [FromBody]Template template)
        {
            var existingTemplate = await _templateService.GetTemplateByIdAsync(id);
            return await _templateService.UpdateTemplateAsync(template);
        }

        /// <summary>
        /// Deletes a specific item.
        /// </summary>
        [HttpDelete("templates/{id}")]
        public async Task<IActionResult> DeleteTemplateAsync([FromRoute]Guid id)
        {
            await _templateService.DeleteTemplateAsync(id);
            return Ok();
        }
    }
}
