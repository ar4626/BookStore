using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Layer.Interface
{
    public  interface IWishListRepository
    {
        public WishListEntity AddBookToWishlist(int userId, int bookId);
        public List<WishListEntity> GetAllBookInWishlist(int userId);
        public WishListEntity DeleteBookInWishlist(int wishlistId);



    }
}
