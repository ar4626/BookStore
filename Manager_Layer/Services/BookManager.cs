using Common_Layer.RequestModel;
using Manager_Layer.Interface;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager_Layer.Services
{
    public class BookManager : IBookManager
    {
        private readonly IBookRepository repository;
        public BookManager(IBookRepository repository)
        {
            this.repository = repository;
        }

        public BookEntitiy AddBook(AddBookModel model, int userId)
        {
            return repository.AddBook(model, userId);
        }
        public List<BookEntitiy> FindAllBook()
        {
            return repository.FindAllBook();
        }
        public List<BookEntitiy> FindBook(string name)
        {
            return repository.FindBook(name);
        }
        public BookEntitiy GetBookById(int bookId)
        {
            return repository.GetBookById(bookId);
        }
        public List<BookEntitiy> SortBookAsceByPrice()
        {
            return repository.SortBookAsceByPrice();
        }
        public List<BookEntitiy> SortBookDescByPrice()
        {
            return repository.SortBookDescByPrice();
        }
        public List<BookEntitiy> SortBookAsceByArrival()
        {
            return repository.SortBookAsceByArrival();
        }
        public List<BookEntitiy> SortBookDescByArrival()
        {
            return repository.SortBookDescByArrival();
        }
        public BookEntitiy UpdateBookQuantity(int userId, int bookId, int quantity)
        {
            return repository.UpdateBookQuantity(userId, bookId, quantity);
        }
        public BookEntitiy UpdateBookPrice(int userId, int bookId, int price)
        {
            return repository.UpdateBookPrice(userId, bookId, price);
        }










    }
}
