﻿using BugManagement.DomainDto;

namespace BugManagement.DomainService
{
    public interface IDomainService
    {
        void CreateUser(UserDomainDto user);
    }
}
