using BookManagerBUS.Extensions;
using BookManagerBUS.QueryModel;
using BookManagerBUS.RequestModel;
using BookManagerBUS.ResponeModel;
using BookManagerDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerBUS.BookBusiness
{
    public interface IBookService
    {
        public const string Message_BookNotFound = "BookNotFound";
        Task<IEnumerable<BookResponeModel>> GetAllAsync(BookQueryModel bookQueryModel);
        Task<Book> GetAsync(Guid id);
        Task<Book> SaveAsync(Book book);
        Task<Book> DeleteAsync(Guid id);
    }
}
