
using System;

namespace GameCom.Model.Base
{
    public abstract class EntityBase<TId>: IEntity<TId>     
    {
        public virtual TId Id { get; set; }

        protected bool IsTransient { get { return Id.Equals(default(TId)); } }

        public override bool Equals(object obj)
        {
            return EntityEquals(obj as EntityBase<TId>);
        }

        protected bool EntityEquals(EntityBase<TId> other)
        {
            if (other == null)
            {
                return false;
            }
            // One entity is transient and the other is not.
            else if (IsTransient ^ other.IsTransient)
            {
                return false;
            }
            // Both entities are not saved.
            else if (IsTransient && other.IsTransient)
            {
                return ReferenceEquals(this, other);
            }
            else
            {
                // Compare transient instances.
                return Id.Equals(other.Id);
            }
        }

        // The hash code is cached because a requirement of a hash code is that
        // it does not change once calculated. For example, if this entity was
        // added to a hashed collection when transient and then saved, we need
        // the same hash code or else it could get lost because it would no 
        // longer live in the same bin.
        private int? cachedHashCode;

        public override int GetHashCode()
        {
            if (cachedHashCode.HasValue) return cachedHashCode.Value;

            cachedHashCode = IsTransient ? base.GetHashCode() : Id.GetHashCode();
            return cachedHashCode.Value;
        }

        // Maintain equality operator semantics for entities.
        public static bool operator ==(EntityBase<TId> x, EntityBase<TId> y)
        {
            // By default, == and Equals compares references. In order to 
            // maintain these semantics with entities, we need to compare by 
            // identity value. The Equals(x, y) override is used to guard 
            // against null values; it then calls EntityEquals().
            return Object.Equals(x, y);
        }

        // Maintain inequality operator semantics for entities. 
        public static bool operator !=(EntityBase<TId> x, EntityBase<TId> y)
        {
            return !(x == y);
        }
    }
}
