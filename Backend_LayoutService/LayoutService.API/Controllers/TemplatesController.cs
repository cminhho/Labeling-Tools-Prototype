﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutService.API.Model;
using LayoutTemplate.API.Service;
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
        public async Task<ActionResult<IEnumerable<Template>>> GetTemplateItems()
        {
            //return await _context.TemplateItems.ToListAsync();
            return await _templateService.GetAllTemplates();
        }

        //// GET: api/Templates/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Template>> GetTemplate(long id)
        //{
        //    var template = await _context.TemplateItems.FindAsync(id);

        //    if (template == null)
        //    {
        //        return NotFound();
        //    }

        //    return template;
        //}

        //// PUT: api/Templates/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTemplate(long id, Template template)
        //{
        //    if (id != template.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(template).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TemplateExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Templates
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Template>> PostTemplate(Template template)
        //{
        //    //_templateService.CreateTemplate(template);
        //    _context.TemplateItems.Add(template);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTemplate", new { id = template.Id }, template);
        //}

        //// DELETE: api/Templates/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Template>> DeleteTemplate(long id)
        //{
        //    var template = await _context.TemplateItems.FindAsync(id);
        //    if (template == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TemplateItems.Remove(template);
        //    await _context.SaveChangesAsync();

        //    return template;
        //}

        //private bool TemplateExists(long id)
        //{
        //    return _context.TemplateItems.Any(e => e.Id == id);
        //}
    }
}
