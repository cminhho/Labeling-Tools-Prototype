using System;
using System.Collections.Generic;

namespace LayoutTemplate.Domain.Common
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
        }

        protected Entity(Guid id)
        {
            this.Id = id;
        }
    }
}
