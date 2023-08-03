using BookManagerBUS.Extensions;
using BookManagerBUS.QueryModel;
using BookManagerEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerBUS.CategoryBusiness
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryEntity> DeleteAsync(Guid id)
        {
           return await _categoryRepository.DeleteAsync(id);
        }

        public async Task<Pagination<CategoryEntity>> GetAllAsync(CategoryQueryModel categoryQueryModel)
        {
            return await _categoryRepository.GetAllAsync(categoryQueryModel);
        }

        public async Task<CategoryEntity> GetAsync(Guid id)
        {
            return await _categoryRepository.GetAsync(id);
        }

        public async Task<CategoryEntity> GetByNameAsync(string name)
        {
            return await _categoryRepository.GetByNameAsync(name);
        }

        public async Task<CategoryEntity> SaveAsync(CategoryEntity category)
        {
            return await _categoryRepository.SaveAsync(category);
        }
    }
}
