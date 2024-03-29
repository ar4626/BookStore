using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager_Layer.Services
{
    public class WishListManager
    {
        private readonly IWishListRepository repository;

        public WishListManager(IWishListRepository repository)
        {
            this.repository = repository;
        }

        public WishListEntity AddBookToWishlist(int userId, int bookId)
        {
            return repository.AddBookToWishlist(userId, bookId);
        }
        public List<WishListEntity> GetAllBookInWishlist(int userId)
        {
            return repository.GetAllBookInWishlist(userId);
        }
        public WishListEntity DeleteBookInWishlist(int wishlistId)
        {
            return repository.DeleteBookInWishlist(wishlistId);
        }



    }
}
