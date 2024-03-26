using Common_Layer.RequestModel;
using Common_Layer.ResponseModel;
using Manager_Layer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository_Layer.Entity;
using System;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager userManager;

        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
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
    }
}
