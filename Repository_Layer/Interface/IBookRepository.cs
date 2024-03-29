using Common_Layer.RequestModel;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Layer.Interface
{
    public interface IBookRepository
    {
        public BookEntitiy AddBook(AddBookModel model, int userId);
        public List<BookEntitiy> FindAllBook();
        public List<BookEntitiy> FindBook(string name);
        public BookEntitiy GetBookById(int bookId);
        public List<BookEntitiy> SortBookAsceByPrice();
        public List<BookEntitiy> SortBookDescByPrice();
        public List<BookEntitiy> SortBookAsceByArrival();
        public List<BookEntitiy> SortBookDescByArrival();
        public BookEntitiy UpdateBookQuantity(int userId, int bookId, int quantity);
        public BookEntitiy UpdateBookPrice(int userId, int bookId, int price);









    }
}
