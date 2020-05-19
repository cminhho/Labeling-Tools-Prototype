using System;

namespace LayoutTemplate.Domain.Common
{
    public class TypedIdValueBase : IEquatable<TypedIdValueBase>
    {
        public Guid Value { get; }

        protected TypedIdValueBase(Guid value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is TypedIdValueBase other && Equals(other);
        }
        public bool Equals(TypedIdValueBase other)
        {
            return this.Value == other.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}
