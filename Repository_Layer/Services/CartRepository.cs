using Repository_Layer.Context;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository_Layer.Services
{
    public class CartRepository : ICartRepository
    {
        private readonly BookStoreContext context;

        public CartRepository(BookStoreContext context)
        {
            this.context = context;
        }

        public CartEntity AddBookToCart(int userId, int bookId)
        {
            CartEntity entity = context.CartTable.FirstOrDefault(a=>a.UserId==userId && a.BookId==bookId);
            if(entity == null)
            {
                CartEntity cart = new CartEntity();
                var book = context.BookTable.FirstOrDefault(b=>b.BookId==bookId);
                cart.UserId = userId;
                cart.BookId = bookId;
                cart.Quantity = 1;
                cart.Price = cart.Quantity * book.Discount;
                context.CartTable.Add(cart);
                context.SaveChanges();
                return cart;
            }
            else
            {
                throw new Exception("Book Already Added in Cart");
            }
        }

        public bool RemoveBookFromCart(int cartId, int userId)
        {
            var cart = context.CartTable.FirstOrDefault(a=>a.CartId==cartId && a.UserId==userId);
            if(cart !=null)
            {
                context.CartTable.Remove(cart);
                context.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Cart Item doesnot belong to User");
            }
        }

        public List<CartEntity> GetAllCartItem(int userId)
        {
            List<CartEntity> items = context.CartTable.Where(a=>a.UserId==userId).ToList();
            return items;
        }

        public int UpdateQuantity(int userId, int bookId, int quantity)
        {
            var cartItem = context.CartTable.FirstOrDefault(a => a.UserId == userId && a.BookId == bookId);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                context.SaveChanges();
                return cartItem.Quantity;
            }
            else
            {
                throw new Exception("Cart item Invalid");
            }
        }
    }
}
