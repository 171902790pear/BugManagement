using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugManagement.DomainModel
{
    public class Project : AggregateRootBase
    {
        public virtual string Name { get; set; }
        public virtual ICollection<Bug> Bugs { get; set; }
    }
}
