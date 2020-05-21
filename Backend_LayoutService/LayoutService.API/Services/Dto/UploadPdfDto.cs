using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutService.API.Services.Dto
{
    public class UploadPdfDto
    {
        public IFormFile Pdf { set; get; }
    }
}
