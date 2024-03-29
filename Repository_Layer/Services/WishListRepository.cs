using Repository_Layer.Context;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository_Layer.Services
{
    public class WishListRepository : IWishListRepository
    {
        private readonly BookStoreContext context;

        public WishListRepository(BookStoreContext context)
        {
            this.context = context;
        }

        public WishListEntity AddBookToWishlist (int userId, int bookId)
        { 
            var book = context.WishListTable.FirstOrDefault(a=>a.BookId == bookId && a.UserId==userId);
            if (book==null)
            {
                WishListEntity entity = new WishListEntity();
                entity.UserId = userId;
                entity.BookId = bookId;
                context.WishListTable.Add(entity);
                context.SaveChanges();
                return entity;
            }
            else
            {
                throw new Exception("Book Already Exist in WishList");
            }
        }

        public List<WishListEntity> GetAllBookInWishlist(int userId)
        {
            var books = context.WishListTable.Where(a=>a.UserId==userId).ToList();
            return books;
        }

        public WishListEntity DeleteBookInWishlist(int wishlistId)
        {
            var book = context.WishListTable.FirstOrDefault(a=>a.WishListId==wishlistId);
            if (book != null)
            {
                context.WishListTable.Remove(book);
                context.SaveChanges();
                return book;
            }
            else
            {
                throw new Exception("Book Doesn't Exist in WishList");
            }
        }
    }
}
