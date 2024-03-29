using Common_Layer.RequestModel;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager_Layer.Interface
{
    public interface IBookManager
    {
        public BookEntitiy AddBook(AddBookModel model, int userId);

    }
}
