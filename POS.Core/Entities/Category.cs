using POS.Core.Aggregates;
using System;

namespace POS.Core.Entities
{
    public class Category : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
