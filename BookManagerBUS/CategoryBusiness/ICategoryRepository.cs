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
    public interface ICategoryRepository
    {
        public const string Message_CategoryNotFound = "CategoryNotFound";
        Task<Pagination<Category>> GetAllAsync(CategoryQueryModel categoryQueryModel);
        Task<Category> GetAsync(Guid id);
        Task<Category> SaveAsync(Category category);
        Task<Category> DeleteAsync(Guid id);
        Task<Category> GetByNameAsync(string name);
        
    }
}
