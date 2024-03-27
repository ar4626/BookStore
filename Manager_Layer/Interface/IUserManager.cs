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
        //public string GenerateToken(string Email, int UserId);

        public ForgetPasswordModel ForgetPassword(string Email);
        public bool CheckUser(string Email);

        public bool ResetPassword(string Email, ResetModel model);

    }
}
