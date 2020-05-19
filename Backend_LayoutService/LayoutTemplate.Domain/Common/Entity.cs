using System;
using System.Collections.Generic;

namespace LayoutTemplate.Domain.Common
{
    public abstract class Entity
    {
        public long Id { get; set; }

        protected Entity()
        {
        }

        protected Entity(long id)
        {
            this.Id = id;
        }
    }
}
