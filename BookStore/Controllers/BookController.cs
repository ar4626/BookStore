using Common_Layer.RequestModel;
using Common_Layer.ResponseModel;
using Manager_Layer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer.Entity;
using System;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookManager bookManager;

        public BookController(IBookManager bookManager)
        {
            this.bookManager = bookManager;
        }

        [Authorize]
        [HttpPost]
        [Route("Add-Book")]
        public ActionResult AddBook(AddBookModel model)
        {
            try
            {
                string role = User.FindFirst("Role").Value.ToLower();
                if(role == "admin")
                {
                    int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                    var book = bookManager.AddBook(model, userId);
                    if(book != null)
                    {
                        return Ok(new ResModel<BookEntitiy> { Success = true, Message = "Book Added Successfully", Data = book });
                    }
                    else
                    {
                        return BadRequest(new ResModel<BookEntitiy> { Success = false, Message = "Something Went Wrong", Data = null });
                    }
                }
                else
                {
                    return BadRequest(new ResModel<bool> { Success = false, Message = "User Not Authorised", Data = false });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }
    }
}
