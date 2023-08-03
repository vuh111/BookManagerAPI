using BookManagerBUS.Extensions;
using BookManagerBUS.QueryModel;
using BookManagerBUS.RequestModel;
using BookManagerBUS.ResponeModel;
using BookManagerEntities.Entities;
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
        Task<BookEntity> GetAsync(Guid id);
        Task<BookEntity> SaveAsync(BookRequestModel book,Guid id);
        Task<BookEntity> DeleteAsync(Guid id);
    }
}
