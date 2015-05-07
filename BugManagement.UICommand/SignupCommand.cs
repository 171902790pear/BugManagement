using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugManagement.UICommand
{
    public class SignupCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string RepeatPassword { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
