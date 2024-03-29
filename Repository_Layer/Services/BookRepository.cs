using Repository_Layer.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Layer.Services
{
    public class BookRepository
    {
        private readonly BookStoreContext context;

        public BookRepository(BookStoreContext context)
        {
            this.context = context;
        }


    }
}
