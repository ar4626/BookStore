using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Common_Layer.RequestModel;
using Repository_Layer.Context;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Repository_Layer.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext context;

        public BookRepository(BookStoreContext context)
        {
            this.context = context;
        }

        public BookEntitiy AddBook(AddBookModel model, int userId)
        {
            var entity = new BookEntitiy();

            Account account = new Account(
              "dxycwp9mh",
              "261612497618837",
              "1Gfedn6FCVHvHlyM-99RxKCaV_M");

            Cloudinary cloudinary = new Cloudinary(account);

            FileDescription fileDescription = new FileDescription(model.Image);

            ImageUploadParams uploadParams = new ImageUploadParams()
            {
                File = fileDescription,
                PublicId = $"{model.BookName}_{model.Author}",
                Folder = "BookStore"
            };

            var Result = cloudinary.Upload(uploadParams);

            entity.UserId = userId;
            entity.BookName = model.BookName;
            entity.BookDesc = model.BookDesc;
            entity.Author = model.Author;
            entity.Quantity = model.Quantity;
            entity.Discount = model.Discount;
            entity.Amount = model.Amount;
            entity.Image = Result.Url.ToString();
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            context.BookTable.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public List<BookEntitiy> FindAllBook()
        {
            return context.BookTable.ToList();
        }

        public List<BookEntitiy> FindBook (string name)
        {
            List<BookEntitiy> list = context.BookTable.Where<BookEntitiy>(a => a.Author.Contains(name) || a.BookName.Contains(name)).ToList();
            return list;
        }

        public BookEntitiy GetBookById (int bookId)
        {
            var entity = context.BookTable.FirstOrDefault(a=> a.BookId == bookId);
            return entity;
        }

        public List<BookEntitiy> SortBookAsceByPrice()
        {
            var list = context.BookTable.OrderBy(a=>a.Amount).ToList();
            return list;
        }

        public List<BookEntitiy> SortBookDescByPrice()
        {
            var list = context.BookTable.OrderByDescending(a=>a.Amount).ToList();
            return list;
        }

        public List<BookEntitiy> SortBookAsceByArrival()
        {
            var list = context.BookTable.OrderBy(a=>a.CreatedAt).ToList();
            return list;
        }

        public List<BookEntitiy> SortBookDescByArrival()
        {
            var list = context.BookTable.OrderByDescending(a=>a.CreatedAt).ToList();
            return list;
        }

    }
}
