using System;
using System.Collections.Generic;
using System.Text;

namespace Common_Layer.ResponseModel
{
    public class UserLogin
    {
        public string Token { get; set; }
        public string FName { get; set; }
        public string Role { get; set; }
    }
}
