using Common_Layer.ResponseModel;
using Manager_Layer.Interface;
using Manager_Layer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer.Entity;
using Repository_Layer.Migrations;
using System;
using System.Collections.Generic;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartManager cartManager;

        public CartController(ICartManager cartManager)
        {
            this.cartManager = cartManager;
        }

        [Authorize]
        [HttpPost]
        [Route("AddToCart")]
        public ActionResult AddToCart(int bookId)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var cart = cartManager.AddBookToCart(userId,bookId);
                if (cart != null)
                {
                    return Ok(new ResModel<CartEntity> { Success = true, Message = "Book Added To Cart Successfully", Data = cart });
                }
                else
                {
                    return BadRequest(new ResModel<CartEntity> { Success = false, Message = "Something Went Wrong", Data = null });
                }
            }
            catch (Exception ex) 
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetCartItems")]
        public ActionResult GetAllItem()
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                List<CartEntity> cartItems = cartManager.GetAllCartItem(userId);
                if (cartItems != null)
                {
                    return Ok(new ResModel<List<CartEntity>> { Success = true, Message = "Cart Fetched Successfully", Data = cartItems });
                }
                else
                {
                    return BadRequest(new ResModel<List<CartEntity>> { Success = false, Message = "Something Went Wrong", Data = null });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("RemoveCartItem")]
        public ActionResult RemoveItem(int cartId)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var deleteCartItem = cartManager.RemoveBookFromCart(cartId, userId);
                if (deleteCartItem)
                {
                    return Ok(new ResModel<bool> { Success = true, Message = "Cart Item Deleted Successfully", Data = deleteCartItem });
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

        [Authorize]
        [HttpPut]
        [Route("UpdateQuantity")]
        public ActionResult UpdateCartBookQuantity(int bookId, int quantity)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var cart = cartManager.UpdateQuantity(userId, bookId, quantity);
                if (cart > 0)
                {
                    return Ok(new ResModel<int> { Success = true, Message = "Item Quantity Changed Successfully", Data = cart });
                }
                else
                {
                    return BadRequest(new ResModel<int> { Success = false, Message = "Something Went Wrong", Data = cart });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }

        }
    }
}
