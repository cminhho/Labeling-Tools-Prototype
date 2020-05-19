using LayoutTemplate.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayoutService.API.Model
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

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }


    }
}
