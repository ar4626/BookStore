﻿using Common_Layer.RequestModel;
using Common_Layer.ResponseModel;
using Common_Layer.Utility;
using Manager_Layer.Interface;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository_Layer.Entity;
using System;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager userManager;
        private readonly IBus bus;

        public UserController(IUserManager userManager, IBus bus)
        {
            this.userManager = userManager;
            this.bus = bus;

        }

        [HttpPost("Register")]
        public ActionResult Register(RegisterModel model)
        {
            try
            {
                var response = userManager.userRegistration(model);
                if (response != null)
                {
                    return Ok(new ResModel<UserEntity> { Success = true, Message = "Registered Successfully", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<UserEntity> { Success = false, Message = "Registration Failed", Data = response });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(new ResModel<string> { Success = false, Message = ex.Message, Data = null});
            }
        }

        [HttpPost("Login")]
        public ActionResult Login(LoginModel model)
        {
            try
            {
                var response = userManager.UserLogin(model);

                if (response != null)
                {
                    return Ok(new ResModel<UserLogin> { Success = true, Message = "Login Successfully", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<UserLogin> { Success = false, Message = "Login Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<string> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPost("ForgetPassword")]
        public async Task<ActionResult> ForgetPassword(string Email)
        {
            try
            {
                if (userManager.CheckUser(Email))
                {
                    Mail mail = new Mail();
                    ForgetPasswordModel model = userManager.ForgetPassword(Email);
                    mail.SendMail(model.Email, model.Token);
                    Uri uri = new Uri("rabbitmq://localhost/BookStoreEmailQueue");
                    var endPoint = await bus.GetSendEndpoint(uri);

                    await endPoint.Send(model);

                    return Ok(new ResModel<string> { Success = true, Message = "Mail Sent Successfully", Data = model.Token });
                }
                else
                {
                    return BadRequest(new ResModel<string> { Success = false, Message = "Email Doesn't Exist", Data = null });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Authorize]
        [HttpPost("ResetPassword")]
        public async Task<ActionResult> ResetPassword(ResetModel model)
        {
            try
            {
                string Email = User.FindFirst("Email").Value;
                if (userManager.ResetPassword(Email, model))
                {
                    return Ok(new ResModel<bool> { Success = true, Message = " Password Changed Successfully", Data = true });
                }
                else
                {
                    return BadRequest(new ResModel<bool> { Success = false, Message = " Password Reset Failed", Data = false });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }
    }
}
