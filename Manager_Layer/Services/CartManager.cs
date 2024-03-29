using Manager_Layer.Interface;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager_Layer.Services
{
    public class CartManager : ICartManager
    {
        private readonly ICartRepository repository;

        public CartManager(ICartRepository repository)
        {
            this.repository = repository;
        }

        public CartEntity AddBookToCart(int userId, int bookId)
        {
            return repository.AddBookToCart(userId, bookId);
        }
        public bool RemoveBookFromCart(int cartId, int userId)
        {
            return repository.RemoveBookFromCart(cartId, userId);
        }
        public List<CartEntity> GetAllCartItem(int userId)
        {
            return repository.GetAllCartItem(userId);   
        }
        public int UpdateQuantity(int userId, int bookId, int quantity)
        {
            return repository.UpdateQuantity(userId, bookId, quantity); 
        }

        public List<CartEntity> PlaceOrder(int userId)
        {
            return repository.PlaceOrder(userId);
        }



    }
}
