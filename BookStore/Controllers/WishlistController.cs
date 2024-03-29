using Common_Layer.ResponseModel;
using Manager_Layer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Net;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IWishListManager wishListManager;

        public WishlistController(IWishListManager wishListManager)
        {
            this.wishListManager = wishListManager;
        }

        [Authorize]
        [HttpPost("AddWishlist")]
        public ActionResult AddToWishlist(int bookId)
        {
            try 
            { 
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var wishlist = wishListManager.AddBookToWishlist(userId, bookId);
                if(wishlist != null)
                {
                    return Ok(new ResModel<WishListEntity> { Success = true, Message = "Book Added To Wishlist Successfully", Data = wishlist });
                }
                else
                {
                    return BadRequest(new ResModel<WishListEntity> { Success = false, Message = "Something Went Wrong", Data = null });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }

        }

        [Authorize]
        [HttpGet]
        [Route("GetAllWishlistBook")]
        public ActionResult GetAllWishListBook()
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var wishlist = wishListManager.GetAllBookInWishlist(userId);
                if (wishlist != null)
                {
                    return Ok(new ResModel<List<WishListEntity>> { Success = true, Message = "Wishlist Fetched Successfully", Data = wishlist });
                }
                else
                {
                    return BadRequest(new ResModel<List<WishListEntity>> { Success = false, Message = "Something Went Wrong", Data = null });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteWishlistBook")]
        public ActionResult DeleteBookInWishlist(int wishlistId)
        {
            try
            {
                var wishlistBook = wishListManager.DeleteBookInWishlist(wishlistId);
                if (wishlistBook != null)
                {
                    return Ok(new ResModel<WishListEntity> { Success = true, Message = "Book Removed From Wishlist", Data = wishlistBook });
                }
                else
                {
                    return BadRequest(new ResModel<WishListEntity> { Success = false, Message = "Something Went Wrong", Data = null });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }
    }
}
