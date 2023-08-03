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
    public interface ICategoryRepository
    {
        public const string Message_CategoryNotFound = "CategoryNotFound";
        Task<Pagination<CategoryEntity>> GetAllAsync(CategoryQueryModel categoryQueryModel);
        Task<CategoryEntity> GetAsync(Guid id);
        Task<CategoryEntity> SaveAsync(CategoryEntity category);
        Task<CategoryEntity> DeleteAsync(Guid id);
        Task<CategoryEntity> GetByNameAsync(string name);
        
    }
}
