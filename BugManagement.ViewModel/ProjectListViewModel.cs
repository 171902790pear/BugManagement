using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugManagement.ViewModel
{
    public class ProjectListViewModel
    {
        public List<Project> Projects { get; set; }

        public class Project
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }
}
