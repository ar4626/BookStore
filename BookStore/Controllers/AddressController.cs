using Common_Layer.RequestModel;
using Common_Layer.ResponseModel;
using Manager_Layer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressManager manager;

        public AddressController(IAddressManager manager)
        {
            this.manager = manager;
        }

        [Authorize]
        [HttpPost]
        [Route("AddAddress")]
        public ActionResult AddAddress(AddAddressModel model)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var address = manager.AddAddress(userId, model);
                if (address != null)
                {
                    return Ok(new ResModel<AddressEntity> { Success = true, Message = "Address Added Successfully", Data = address });
                }
                else
                {
                    return BadRequest(new ResModel<AddressEntity> { Success = false, Message = "Something Went Wrong", Data = null });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("UpdateAddress")]
        public ActionResult UpdateAddress(int AddressId, AddAddressModel model)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var address = manager.UpdateAddress(userId, model, AddressId);
                if (address != null)
                {
                    return Ok(new ResModel<AddressEntity> { Success = true, Message = "Address Updated Successfully", Data = address });
                }
                else
                {
                    return BadRequest(new ResModel<AddressEntity> { Success = false, Message = "Something Went Wrong", Data = null });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllAddress")]
        public ActionResult GetAllAddress()
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var address = manager.GetAllAddresses(userId);
                if (address != null)
                {
                    return Ok(new ResModel<List<AddressEntity>> { Success = true, Message = "Address Fetched Successfully", Data = address });
                }
                else
                {
                    return BadRequest(new ResModel<List<BookEntitiy>> { Success = false, Message = "Something Went Wrong", Data = null });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteAddress")]
        public ActionResult DeleteAddress(int addressId)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var address = manager.DeleteAddress(addressId, userId);
                if (address == true)
                {
                    return Ok(new ResModel<bool> { Success = true, Message = "Address Removed Successfully", Data = address });
                }
                else
                {
                    return BadRequest(new ResModel<bool> { Success = false, Message = "Something Went Wrong", Data = false });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }

    }
}
