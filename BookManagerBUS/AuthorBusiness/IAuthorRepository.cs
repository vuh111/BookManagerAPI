using BookManagerBUS.Extensions;
using BookManagerBUS.QueryModel;
using BookManagerBUS.RequestModel;
using BookManagerDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerBUS.AuthorBusiness
{
    public interface IAuthorRepository
    {
        public const string Message_AuthorNotFound = "AuthorNotFound";
        Task<Pagination<Author>> GetAllAsync(AuthorQueryModel authorQueryModel);
        Task<Author> GetAsync(Guid id);
        Task<Author> SaveAsync(Author author);
        Task <Author>DeleteAsync(Guid id);
        Task<Author> GetByNameAsync(string name);

    }
}
