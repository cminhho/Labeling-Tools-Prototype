using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LayoutService.API.Common;
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

        /// <summary>
        /// Gets all items.
        /// </summary>
        [HttpGet("templatetype")]
        public async Task<IEnumerable<TemplateType>> GetTemplateTypeItemsAsync()
        {
            return await _templateTypeService.GetAllTemplateTypesAsync();
        }

        /// <summary>
        /// Gets a specific item.
        /// </summary>
        [HttpGet("templatetype/{id}")]
        public async Task<ActionResult<TemplateType>> GetTemplateTypeAsync(Guid id)
        {
            var templateType = await _templateTypeService.GetTemplateTypeByIdAsync(id);
            return ActionResultUtil.WrapOrNotFound(templateType);
        }

        /// <summary>
        /// Updates a specific item.
        /// </summary>
        [HttpPut("templatetype/{id}")]
        public async Task<ActionResult<TemplateType>> PutTemplateTypeAsync(long id, TemplateType TemplateType)
        {
            return await _templateTypeService.UpdateTemplateTypeAsync(TemplateType);
        }

        /// <summary>
        /// Creates a specific item.
        /// </summary>
        [HttpPost("templatetype")]
        public async Task<ActionResult<TemplateType>> PostTemplateTypeAsync(TemplateType TemplateType)
        {
            return await _templateTypeService.CreateTemplateTypeAsync(TemplateType);
        }

        /// <summary>
        /// Deletes a specific item.
        /// </summary>
        [HttpDelete("templatetype/{id}")]
        public async Task<ActionResult<TemplateType>> DeleteTemplateTypeAsync(Guid id)
        {
            await _templateTypeService.DeleteTemplateTypeAsync(id);
            return Ok();
        }
    }
}
