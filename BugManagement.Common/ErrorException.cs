using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugManagement.Common
{
    public class ErrorInfo
    {
        public string Name { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class ErrorException : Exception
    {
        public ErrorException(List<ErrorInfo> errors)
        {
            Errors = errors;
        }
        public List<ErrorInfo> Errors { get; set; }
    }
}
