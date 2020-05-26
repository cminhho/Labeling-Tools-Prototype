using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutService.API.Common
{
    public class ActionResultUtil
    {
        public static ActionResult WrapOrNotFound(object value)
        {
            return value != null ? (ActionResult)new OkObjectResult(value) : new NotFoundResult();
        }
    }
}
