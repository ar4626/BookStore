using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager_Layer.Interface
{
    public interface IWishListManager
    {
        public WishListEntity AddBookToWishlist(int userId, int bookId);
        public List<WishListEntity> GetAllBookInWishlist(int userId);
        public WishListEntity DeleteBookInWishlist(int wishlistId);

    }
}
