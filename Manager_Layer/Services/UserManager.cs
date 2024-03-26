﻿using Common_Layer.RequestModel;
using Common_Layer.ResponseModel;
using Manager_Layer.Interface;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager_Layer.Services
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository repository;

        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        public UserEntity userRegistration(RegisterModel model)
        {
            return repository.userRegistration(model);
        }
        public UserLogin UserLogin(LoginModel model)
        {
            return repository.UserLogin(model);
        }


    }
}