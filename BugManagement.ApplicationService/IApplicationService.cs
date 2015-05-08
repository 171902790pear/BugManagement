﻿using BugManagement.ApplicationDto;

namespace BugManagement.ApplicationService
{
    public interface IApplicationService
    {
        void Signup(UserApplicationDto user);
        bool CheckUsernameExist(string username);
    }
}
