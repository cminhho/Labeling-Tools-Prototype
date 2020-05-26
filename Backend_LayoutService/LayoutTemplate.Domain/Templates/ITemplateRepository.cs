using LayoutService.Domain.Templates;
using LayoutTemplate.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LayoutTemplate.Domain.Templates
{
    public interface ITemplateRepository : IAsyncRepository<Template>
    {
    }
}
