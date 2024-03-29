﻿using Common_Layer.RequestModel;
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

    }
}