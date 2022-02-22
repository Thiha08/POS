using System;

namespace POS.Core.Aggregates
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public DateTime UpdatedOnUtc { get; set; }

        public bool Status { get; set; }
    }
}
