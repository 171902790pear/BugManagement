using System;
using System.Collections.Generic;

namespace BugManagement.DomainModel
{
    public class Bug : AggregateRootBase
    {
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }

        public virtual Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public virtual int? Status { get; set; }

        public virtual User Assigner { get; set; }
        public virtual Guid AssignerId { get; set; }

        public virtual ICollection<BugOperationRecord> OperationRecords { get; set; }

        public void Solve(User solveBy)
        {
            Status=(int)BugStatus.Solved;
            var operateRecord = new BugOperationRecord()
                                {
                                    Id = Guid.NewGuid(),
                                    OperateTime = DateTime.Now,
                                    Operater = solveBy,
                                    Operate = (int) BugOperate.Solve
                                };
            OperationRecords.Add(operateRecord);
        }

        public void Reopen(User reopenBy)
        {
            Status = (int)BugStatus.Reopened;
            var operateRecord = new BugOperationRecord()
                                {
                                    Id = Guid.NewGuid(),
                                    OperateTime = DateTime.Now,
                                    Operater = reopenBy,
                                    Operate = (int)BugOperate.Reopen
                                };
            OperationRecords.Add(operateRecord);
        }


    }
}