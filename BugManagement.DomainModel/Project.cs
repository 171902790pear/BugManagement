using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugManagement.DomainModel
{
    public class Project
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Bug> Bugs { get; set; }
    }

    public class Bug
    {
        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }

        public virtual Project Project { get; set; }

        public virtual int? Status { get; set; }

        public virtual User Assigner { get; set; }

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
    public class BugOperationRecord
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime? OperateTime { get; set; }
        public virtual User Operater { get; set; }
        public virtual int? Operate { get; set; }
    }

    public enum BugOperate
    {
        Open=1,
        Solve=2,
        Reopen=3,
        Close=4
    }

    public enum BugStatus
    {
        Opened=1,
        Solved=2,
        Reopened=3,
        Closed=4
    }

    public class User
    {
        public virtual Guid Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }


    }

}
