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
    public class AuthorService : IAutherService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> DeleteAsync(Guid id)
        {
            return await _authorRepository.DeleteAsync(id);
        }

        public async Task<Pagination<Author>> GetAllAsync(AuthorQueryModel authorQueryModel)
        {
            return await _authorRepository.GetAllAsync(authorQueryModel);
        }

        public async Task<Author> GetAsync(Guid id)
        {
            return await _authorRepository.GetAsync(id);
        }

        public async Task<Author> GetByNameAsync(string name)
        {
            return await _authorRepository.GetByNameAsync(name);
        }

        public async Task<Author> SaveAsync(Author author)
        {
            return await _authorRepository.SaveAsync(author);
        }
    }
}
