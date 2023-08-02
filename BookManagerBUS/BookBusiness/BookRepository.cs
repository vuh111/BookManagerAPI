using BookManagerBUS.Extensions;
using BookManagerBUS.QueryModel;
using BookManagerDAL;
using BookManagerDAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerBUS.BookBusiness
{
    public class BookRepository : IBookRepository
    {
        private readonly BookManagerDbcontext _dataContext;
        public BookRepository(BookManagerDbcontext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Book> DeleteAsync(Guid id)
        {
            var book= await _dataContext.Books.FirstOrDefaultAsync(x=>x.Id==id);
            if (book==null)
            {
                throw new System.ArgumentException(IBookRepository.Message_BookNotFound);
            }
            book.IsActive = false;
            _dataContext.Books.Update(book);
            await _dataContext.SaveChangesAsync();

            return book;
        }

        public async Task<Pagination<Book>> GetAllAsync(BookQueryModel bookQueryModel)
        {
            bookQueryModel.PageSize= bookQueryModel.PageSize.HasValue? bookQueryModel.PageSize:20;
            bookQueryModel.CurrentPage = bookQueryModel.CurrentPage.HasValue ? bookQueryModel.CurrentPage.Value : 1;


            var query =  _dataContext.Books.AsQueryable()
                                           .Where(x=>x.IsActive ==true);

            return  await query.GetPagedAsync<Book>(bookQueryModel.CurrentPage.Value, bookQueryModel.PageSize.Value);
        }

        public async Task<Book> GetAsync(Guid id)
        {
            var result = await _dataContext.Books.FirstOrDefaultAsync(x=>x.Id== id&& x.IsActive==true);
            return result;
        }

        public async Task<Book> SaveAsync(Book book)
        {
            if (book.Id == Guid.Empty)
            {
                book.Id = Guid.NewGuid();
                book.CreateDate = DateTime.Now;
                await _dataContext.Books.AddAsync(book);
            }
            else
            {
                var bookUpdate= await GetAsync(book.Id);
                if(bookUpdate==null)
                {
                    throw new System.ArgumentException(IBookRepository.Message_BookNotFound);
                }
                bookUpdate.Name=book.Name;
                bookUpdate.PublicDate = book.PublicDate;
                bookUpdate.CreateDate = book.CreateDate;
                bookUpdate.AuthorId=book.AuthorId;
                bookUpdate.CategoryId =book.CategoryId;
                _dataContext.Books.Update(bookUpdate);

            }
            await _dataContext.SaveChangesAsync();
            return book;
        }
    }
}
