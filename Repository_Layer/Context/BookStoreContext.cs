using Microsoft.EntityFrameworkCore;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Layer.Context
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions options) : base(options) { }

        public DbSet<UserEntity> UserTable { get; set; }
        public DbSet<BookEntitiy> BookTable { get; set; }
        public DbSet<CartEntity> CartTable { get; set; }
        public DbSet<WishListEntity> WishListTable { get; set;} 
    }
}
