using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIMS.Domain.Common
{
    /// <summary>
    /// Base class for all domain entities.
    /// Provides common properties such as Id and audit fields.
    /// Questions: 1. Why abstract? Why protected set? Why Guid? What will happen at NewGuid();?
    /// </summary>
    public abstract class BaseEntity
    {
        // Unique identifier for the entity
        public Guid Id { get; protected set; }

        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Updates the modification timestamp.
        /// Called whenever an entity is changed.
        /// </summary>
        protected void MarkAsUpdated()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
