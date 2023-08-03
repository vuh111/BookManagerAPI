using BookManagerBUS.Extensions;
using BookManagerBUS.QueryModel;
using BookManagerBUS.RequestModel;
using BookManagerEntities.Entities;
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
        Task<Pagination<BookEntity>> GetAllAsync(BookQueryModel bookQueryModel);
        Task<BookEntity> GetAsync(Guid id);
        Task<BookEntity> SaveAsync(BookEntity book);
        Task<BookEntity> DeleteAsync(Guid id);
    }
}
