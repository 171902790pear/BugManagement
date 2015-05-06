using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugManagement.DomainDto;
using BugManagement.DomainModel;

namespace BugManagement.DomainFactory
{
    public interface IUserFactory
    {
         User Create(UserDomainDto userDto);
    }

    public class UserFactory : IUserFactory
    {
        public User Create(UserDomainDto userDto)
        {
            return new User()
            {
                Id=Guid.NewGuid(),
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Username = userDto.Username,
                Password = userDto.Password
            };
        }
    }
}
