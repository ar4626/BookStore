using Common_Layer.RequestModel;
using Common_Layer.ResponseModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository_Layer.Context;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Repository_Layer.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly BookStoreContext context;
        private readonly IConfiguration _config;

        public UserRepository(BookStoreContext context, IConfiguration config)
        {
            this.context = context;
            this._config = config;
        }

        public UserEntity userRegistration(RegisterModel model)
        {
            if(context.UserTable.FirstOrDefault(a=>a.Email == model.Email) == null)
            {
                UserEntity entity = new UserEntity();
                entity.FName = model.FName;
                entity.Lname = model.Lname;
                entity.Email = model.Email;
                entity.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
                entity.Mobile = model.Mobile;
                entity.CreatedAt = DateTime.Now;
                entity.UpdatedAt = DateTime.Now;
                context.UserTable.Add(entity);
                context.SaveChanges();
                return entity;
            }
            else
            {
                throw new Exception("User Already Exist.");
            }
        }

        public UserLogin UserLogin(LoginModel model)
        {

            var user = context.UserTable.FirstOrDefault(a => a.Email == model.Email);
            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                {
                    string token = GenerateToken(user.Email, user.UserId, user.Role);
                    return new UserLogin{
                        Token= token,
                        FName= user.FName,
                    };
                }
                else
                {
                    throw new Exception("Invalid Password!");
                }
            }
            else
            {
                throw new Exception("User Not Found");
            }
        }

        private string GenerateToken(string Email, int UserId, string Role)
        {
            //Defining a Security Key 
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Email",Email),
                new Claim("Role",Role),
                new Claim("UserId", UserId.ToString())
            };
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Token expiration time
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;

        }

        public ForgetPasswordModel ForgetPassword(string Email)
        {
            UserEntity User = context.UserTable.FirstOrDefault(x => x.Email == Email);
            ForgetPasswordModel forgetPassword = new ForgetPasswordModel();
            forgetPassword.Email = User.Email;
            forgetPassword.UserId = User.UserId;
            forgetPassword.Token = GenerateToken(Email, User.UserId, User.Role);
            return forgetPassword;
        }

        public bool CheckUser(string Email)
        {
            if (context.UserTable.FirstOrDefault(a => a.Email == Email) == null) return false;
            return true;
        }

        public bool ResetPassword(string Email, ResetModel model)
        {
            UserEntity user = context.UserTable.ToList().Find(x => x.Email == Email);

            if (CheckUser(user.Email))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
