using BookManagerBUS.Extensions;
using BookManagerBUS.QueryModel;
using BookManagerDAL;
using BookManagerEntities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerBUS.CategoryBusiness
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookManagerDbcontext _dbContext;
        public CategoryRepository(BookManagerDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CategoryEntity> GetByNameAsync(string name)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x=>x.CategoryName== name);
            if( category == null)
            {
                throw new ArgumentException(ICategoryRepository.Message_CategoryNotFound);
            }
            return category;
        }
        public async Task<CategoryEntity> DeleteAsync(Guid id)
        {
            var category = await GetAsync(id);
            if (category == null) {
                throw new ArgumentException(ICategoryRepository.Message_CategoryNotFound);
            }
            category.IsActive= false;
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Pagination<CategoryEntity>> GetAllAsync(CategoryQueryModel categoryQueryModel)
        {
            categoryQueryModel.PageSize = categoryQueryModel.PageSize.HasValue ? categoryQueryModel.PageSize : 20;
            categoryQueryModel.CurrentPage = categoryQueryModel.CurrentPage.HasValue ? categoryQueryModel.CurrentPage.Value : 1;
            var query = _dbContext.Categories.AsQueryable().Where(x => x.IsActive == true);
            return await query.GetPagedAsync<CategoryEntity>(categoryQueryModel.CurrentPage.Value, categoryQueryModel.PageSize.Value);
        }

        public async Task<CategoryEntity> GetAsync(Guid id)
        {
            var book = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
            if (book == null)
            {
                throw new System.ArgumentException(ICategoryRepository.Message_CategoryNotFound);
            }
            return book;
        }

        public async Task<CategoryEntity> SaveAsync(CategoryEntity category)
        {
            if(category.Id==Guid.Empty)
            {
                category.Id = Guid.NewGuid();
                await _dbContext.Categories.AddAsync(category);
            }
            else
            {

                var categoryUpdate= await GetAsync(category.Id);
                if(categoryUpdate==null)
                {
                    throw new ArgumentException(ICategoryRepository.Message_CategoryNotFound);
                }
                categoryUpdate.CategoryName = category.CategoryName;
                categoryUpdate.Description=category.Description;
                categoryUpdate.Code = category.Code;
                _dbContext.Categories.Update(categoryUpdate);
            }
            await _dbContext.SaveChangesAsync();
            return category;
        }
    }
}
