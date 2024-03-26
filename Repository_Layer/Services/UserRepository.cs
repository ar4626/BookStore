using Repository_Layer.Context;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Layer.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly BookStoreContext context;

        public UserRepository(BookStoreContext context)
        {
            this.context = context;
        }

        //public UserEntity userRegistration()
    }
}
