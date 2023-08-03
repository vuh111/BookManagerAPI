using BookManagerBUS.Extensions;
using BookManagerBUS.QueryModel;
using BookManagerBUS.RequestModel;
using BookManagerDAL;
using BookManagerEntities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerBUS.AuthorBusiness
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookManagerDbcontext _dataContext;

        public AuthorRepository(BookManagerDbcontext bookManagerDbcontext)
        {
            _dataContext = bookManagerDbcontext;
        }

        public async Task<AuthorEntity> GetByNameAsync(string name)
        {
            var author= await _dataContext.Authors.FirstOrDefaultAsync(x=>x.Name==name);
            if (author == null)
            {
                throw new System.ArgumentException(IAuthorRepository.Message_AuthorNotFound);
            }
            return author;
        }
        public async Task<AuthorEntity> DeleteAsync(Guid Id)
        {
            var author =await _dataContext.Authors.FirstOrDefaultAsync(x => x.Id == Id);
            if (author == null)
            {
                throw new System.ArgumentException(IAuthorRepository.Message_AuthorNotFound);
            }
            author.IsActive = false;
            _dataContext.Authors.Update(author);
            await _dataContext.SaveChangesAsync();
            return author;

        }

        public async Task<AuthorEntity> GetAsync(Guid Id)
        {
            var result = await _dataContext.Authors.FirstOrDefaultAsync(x=> x.Id == Id && x.IsActive==true);
            return result;
        }

        public async Task<Pagination<AuthorEntity> >GetAllAsync(AuthorQueryModel authorQueryModel)
        {
            authorQueryModel.PageSize = authorQueryModel.PageSize.HasValue ? authorQueryModel.PageSize : 20;
            authorQueryModel.CurrentPage = authorQueryModel.CurrentPage.HasValue ? authorQueryModel.CurrentPage.Value : 1;

            var query = _dataContext.Authors.AsQueryable().Where(x=>x.IsActive ==true);



            return await query.GetPagedAsync<AuthorEntity>(authorQueryModel.CurrentPage.Value, authorQueryModel.PageSize.Value);
        } 
        public async Task<AuthorEntity> SaveAsync(AuthorEntity author)
        {
            if (author.Id == Guid.Empty)
            {
                author.Id = Guid.NewGuid();
                await _dataContext.Authors.AddAsync(author);
            }
            else
            {
                var authorUpdate = await GetAsync(author.Id);
                if(authorUpdate == null) {
                    throw new System.ArgumentException(IAuthorRepository.Message_AuthorNotFound);
                }
                authorUpdate.Name = author.Name;
                authorUpdate.Brithday = author.Brithday;
                authorUpdate.National = author.National;
            }
            await _dataContext.SaveChangesAsync();
            return author;
        }


    }
}
