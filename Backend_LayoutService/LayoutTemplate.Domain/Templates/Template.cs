using LayoutTemplate.Domain.Common;
using LayoutTemplate.Domain.TemplateTypes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayoutService.Domain.Templates
{
    public class Template : Entity, IAggregateRoot, IAuditedEntityBase
    {

        [StringLength(150)]
        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("is_complete")]
        public bool IsComplete { get; set; }

        [StringLength(150)]
        [Column("code")]
        public string Code { get; set; }

        [StringLength(150)]
        [Column("model_id")]
        public string ModelId { get; set; }

        public virtual TemplateType templateType { get; set; }

        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
