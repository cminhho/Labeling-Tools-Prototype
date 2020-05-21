﻿using LayoutTemplate.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayoutTemplate.Domain.TemplateTypes
{
    public class TemplateType : Entity, IAggregateRoot, IAuditedEntityBase
    {
        [StringLength(150)]
        [Column("name")]
        [Required]
        public string Name { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
