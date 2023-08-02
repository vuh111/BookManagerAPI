using BookManagerBUS.Extensions;
using BookManagerBUS.QueryModel;
using BookManagerBUS.RequestModel;
using BookManagerDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerBUS.BookBusiness
{
    public interface IBookRepository
    {
        public const string Message_BookNotFound = "BookNotFound";
        Task<Pagination<Book>> GetAllAsync(BookQueryModel bookQueryModel);
        Task<Book> GetAsync(Guid id);
        Task<Book> SaveAsync(Book book);
        Task<Book> DeleteAsync(Guid id);
    }
}
