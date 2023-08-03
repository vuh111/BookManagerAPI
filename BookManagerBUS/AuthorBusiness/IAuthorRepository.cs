using BookManagerBUS.Extensions;
using BookManagerBUS.QueryModel;
using BookManagerBUS.RequestModel;
using BookManagerEntities.Entities;
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
        Task<Pagination<AuthorEntity>> GetAllAsync(AuthorQueryModel authorQueryModel);
        Task<AuthorEntity> GetAsync(Guid id);
        Task<AuthorEntity> SaveAsync(AuthorEntity author);
        Task <AuthorEntity> DeleteAsync(Guid id);
        Task<AuthorEntity> GetByNameAsync(string name);

    }
}
