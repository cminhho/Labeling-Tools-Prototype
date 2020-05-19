using System;
using System.ComponentModel.DataAnnotations;

namespace LayoutTemplate.API.Services.Dto
{
    public class TemplateDto
    { 
        [MinLength(1)]
        [MaxLength(150)]
        public string name { get; set; }

        public TemplateDto()
        {
        }

        public TemplateDto(string name)
        {
            this.name = name;
        }
    }
}
