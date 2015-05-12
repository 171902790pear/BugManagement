using System;

namespace BugManagement.DomainModel
{
    public abstract class EntityBase
    {
        public virtual Guid Id { get; set; }
    }
}