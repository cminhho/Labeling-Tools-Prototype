using System;
using System.ComponentModel.DataAnnotations;

namespace LayoutService.API.Templates
{
    public class CreateTemplateDto
    { 
        [MinLength(1)]
        [MaxLength(150)]
        public string name { get; set; }

        public CreateTemplateDto()
        {
        }

        public CreateTemplateDto(string name)
        {
            this.name = name;
        }
    }
}
