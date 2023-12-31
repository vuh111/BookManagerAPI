﻿
using BookManagerEntities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerDAL
{
    public class BookManagerDbcontext : DbContext
    {
        public BookManagerDbcontext()
        {
        }
        public BookManagerDbcontext(DbContextOptions options) : base(options)
        {
        }

       
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Data Source=LAPTOP-IHE70EQ6\SQLEXPRESS;Initial Catalog=book_test;Persist Security Info=True;User ID=DBSET;Password=123");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
