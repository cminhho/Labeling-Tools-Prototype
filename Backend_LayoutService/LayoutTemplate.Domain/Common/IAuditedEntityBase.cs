using System;
using System.Collections.Generic;
using System.Text;

namespace LayoutTemplate.Domain.Common
{
    public interface IAuditedEntityBase
    {
        string CreatedBy { get; set; }

        DateTime CreatedDate { get; set; }

        string LastModifiedBy { get; set; }

        DateTime LastModifiedDate { get; set; }
    }
}
