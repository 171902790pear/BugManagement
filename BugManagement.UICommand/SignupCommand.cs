using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugManagement.Common;

namespace BugManagement.UICommand
{
    public class SignupCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public IEnumerable<ErrorInfo> Validation()
        {
            if (string.IsNullOrEmpty(Username))
            {
                yield return
                    new ErrorInfo()
                    {
                        Name = "Username",
                        ErrorMessage = "The Username can not be empty."
                    };
            }
            if (string.IsNullOrEmpty(Password))
            {
                yield return
                    new ErrorInfo()
                    {
                        Name = "Password",
                        ErrorMessage = "The Password can not be empty."
                    };
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
            if (Password != RepeatPassword)
            {
                yield return
                    new ErrorInfo()
                    {
                        Name = "RepeatPassword",
                        ErrorMessage = "The passwords you typed twice do not match."
                    };
            }
            if (FirstName.Length > 16)
            {
                yield return
                    new ErrorInfo()
                    {
                        Name = "FirstName",
                        ErrorMessage = "The length of FirstName must be less than 16."
                    };
            }
            if (LastName.Length > 16)
            {
                yield return
                    new ErrorInfo()
                    {
                        Name = "LastName",
                        ErrorMessage = "The length of LastName must be less than 16."
                    };
            }
        }
    }
}
