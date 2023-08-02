using BookManagerBUS.Extensions;
using BookManagerBUS.QueryModel;
using BookManagerDAL.Model;
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

        public async Task<Category> DeleteAsync(Guid id)
        {
           return await _categoryRepository.DeleteAsync(id);
        }

        public async Task<Pagination<Category>> GetAllAsync(CategoryQueryModel categoryQueryModel)
        {
            return await _categoryRepository.GetAllAsync(categoryQueryModel);
        }

        public async Task<Category> GetAsync(Guid id)
        {
            return await _categoryRepository.GetAsync(id);
        }

        public async Task<Category> GetByNameAsync(string name)
        {
            return await _categoryRepository.GetByNameAsync(name);
        }

        public async Task<Category> SaveAsync(Category category)
        {
            return await _categoryRepository.SaveAsync(category);
        }
    }
}
