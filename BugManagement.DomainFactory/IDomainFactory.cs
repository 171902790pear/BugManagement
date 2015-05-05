using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugManagement.DomainModel;

namespace BugManagement.DomainFactory
{
    public interface IDomainFactory<out T>
    {
         T Create();
    }

    public class UserFactory : IDomainFactory<User>
    {
        public User Create()
        {
            throw new NotImplementedException();
        }
    }
}
