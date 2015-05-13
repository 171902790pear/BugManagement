using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugManagement.Common;

namespace BugManagement.UICommand
{
    public class SignInCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public IEnumerable<ErrorInfo> Validation()
        {
            if (string.IsNullOrEmpty(Username))
            {
                yield return new ErrorInfo() { Name = "Username", ErrorMessage = "Username can not be empty" };
            }
            if (string.IsNullOrEmpty(Password))
            {
                yield return new ErrorInfo() { Name = "Password", ErrorMessage = "Password can not be empty" };
            }
            if (Username.Length > 16)
            {
                yield return
                    new ErrorInfo()
                    {
                        Name = "Username",
                        ErrorMessage = "The length of Username must be less than 16."
                    };
            }
            if (Password.Length > 16)
            {
                yield return
                    new ErrorInfo()
                    {
                        Name = "Password",
                        ErrorMessage = "The length of Password must be less than 16."
                    };
            }
        }
    }
}
