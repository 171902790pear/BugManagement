using System.Collections.Generic;

namespace BugManagement.DomainModel
{
    public class User : AggregateRootBase
    {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual ICollection<Bug> Bugs { get; set; }
        public virtual ICollection<BugOperationRecord> BugOperationRecords { get; set; }
    }
}