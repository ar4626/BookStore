using Common_Layer.RequestModel;
using Common_Layer.ResponseModel;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager_Layer.Interface
{
    public interface IUserManager
    {
        public UserEntity userRegistration(RegisterModel model);
        public UserLogin UserLogin(LoginModel model);


    }
}
