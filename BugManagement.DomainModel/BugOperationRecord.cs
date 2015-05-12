using System;

namespace BugManagement.DomainModel
{
    public class BugOperationRecord : EntityBase
    {
        public virtual DateTime? OperateTime { get; set; }
        public virtual User Operater { get; set; }
        public virtual int? Operate { get; set; }
        public virtual Guid OperaterId { get; set; }
        public virtual Bug Bug { get; set; }
        public virtual Guid BugId { get; set; }
    }
}