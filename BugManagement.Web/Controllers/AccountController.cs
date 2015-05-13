﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BugManagement.Common;
using BugManagement.UICommand;
using BugManagement.UIService;
using BugManagement.Web.Models;

namespace BugManagement.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUIService _service;
        
        public AccountController(IUIService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup([ModelBinder(typeof(JsonBinder<SignupCommand>))]SignupCommand signupCommand)
        {
            var errors = new List<ErrorInfo>();
            var exist=_service.CheckUsernameExist(signupCommand.Username);
            if (exist)
            {
                errors.Add(new ErrorInfo() { Name = "Username", ErrorMessage = "The username is already exist!" });
            }
            errors.AddRange(signupCommand.Validation().ToList());
            if (errors.Any())
            {
                throw new ErrorException(errors);
            }
            _service.Signup(signupCommand);
            return SuccessResult();
        }

        [HttpPost]
        public ActionResult CheckUserName(string username)
        {
            var exist=_service.CheckUsernameExist(username);
            if (exist)
            {
                throw new ErrorException(new List<ErrorInfo>(){new ErrorInfo(){ErrorMessage = "The username is already exist!"}});
            }
            return SuccessResult();
        }

        [HttpGet]
        public ActionResult SignIn(string username = "")
        {
            return View(username);
        }

        [HttpPost]
        public ActionResult SignIn([ModelBinder(typeof(JsonBinder<SignInCommand>))]SignInCommand command)
        {
            var errors = command.Validation().ToList();
            if (errors.Any())
            {
                throw new ErrorException(errors);
            }
            var result=_service.SignIn(command);
            if (!result)
            {
                throw new ErrorException(new List<ErrorInfo>(){new ErrorInfo(){Name = "Username",ErrorMessage = "Username or password is error"}});
            }
            return SuccessResult();
        }
    }
}
