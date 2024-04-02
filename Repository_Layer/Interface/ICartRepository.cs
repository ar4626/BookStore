using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Layer.Interface
{
    public interface ICartRepository
    {
        public CartEntity AddBookToCart(int userId, int bookId);
        public bool RemoveBookFromCart(int cartId, int userId);
        public List<CartEntity> GetAllCartItem(int userId);
        public int UpdateQuantity(int userId, int bookId, int quantity);
        public List<CartEntity> PlaceOrder(int userId);
        public int GetCartCount(int userId);



    }
}
