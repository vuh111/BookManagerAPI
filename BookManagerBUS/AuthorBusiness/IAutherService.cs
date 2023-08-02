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
    public interface IAutherService
    {
        Task<Pagination<Author>> GetAllAsync(AuthorQueryModel  authorQueryModel);
        Task<Author> GetAsync(Guid id);
        Task<Author> SaveAsync(Author author);
        Task<Author> DeleteAsync(Guid id);
        Task<Author> GetByNameAsync(string name);
    }
}
