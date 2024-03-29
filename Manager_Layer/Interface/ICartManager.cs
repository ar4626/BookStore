using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager_Layer.Interface
{
    public interface ICartManager
    {
        public CartEntity AddBookToCart(int userId, int bookId);
        public bool RemoveBookFromCart(int cartId, int userId);
        public List<CartEntity> GetAllCartItem(int userId);
        public int UpdateQuantity(int userId, int bookId, int quantity);
    }
}
