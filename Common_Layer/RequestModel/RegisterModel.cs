using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common_Layer.RequestModel
{
    public class RegisterModel
    {
        //[RegularExpression("^[A-Z][a-z]{2,}", ErrorMessage = "Your input should start from caps with a min length 3")]
        public string FName { get; set; }
        //[RegularExpression("^[A-Z][a-z]{2,}", ErrorMessage = "Your input should start from caps with a min length 3")]
        public string Lname { get; set; }
        public string Mobile { get; set; }
        //[DataType(DataType.EmailAddress, ErrorMessage = "Enter a valid Email")]
        public string Email { get; set; }
        //[DataType(DataType.Password, ErrorMessage = "Enter a strong Password")]
        public string Password { get; set; }

    }
}
