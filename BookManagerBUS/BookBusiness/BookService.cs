using BookManagerBUS.AuthorBusiness;
using BookManagerBUS.CategoryBusiness;
using BookManagerBUS.Extensions;
using BookManagerBUS.QueryModel;
using BookManagerBUS.RequestModel;
using BookManagerBUS.ResponeModel;
using BookManagerEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerBUS.BookBusiness
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<BookEntity> DeleteAsync(Guid id)
        {
            return await _bookRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<BookResponeModel>> GetAllAsync(BookQueryModel bookQueryModel)
        {
            var books=await _bookRepository.GetAllAsync(bookQueryModel);
            
            var result = new List<BookResponeModel>();
            foreach (var item in books.Content) {
                var author = await _authorRepository.GetAsync(item.AuthorId);
                var category = await _categoryRepository.GetAsync(item.CategoryId);
                result.Add(new BookResponeModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    PublicDate = item.PublicDate,
                    CreateDate = item.CreateDate,
                    Active = item.IsActive,
                    Author = (author!=null)?author:null,
                    Category = (category!=null)?category:null,
                });
            }
           
            return result;
        }

        public async Task<BookEntity> GetAsync(Guid id)
        {
            return await _bookRepository.GetAsync(id);
        }

        public async Task<BookEntity> SaveAsync(BookRequestModel  bookRequestModel,Guid id)
        {
            var booksAuthor = await _authorRepository.GetByNameAsync(bookRequestModel.AuthorName);
            var booksCategory = await _categoryRepository.GetByNameAsync(bookRequestModel.CategoryName);
  
            var book = new BookEntity()
            {
                Id = id,
                AuthorId = booksAuthor.Id,
                CategoryId = booksCategory.Id,
                Name = bookRequestModel.Name,
                PublicDate = bookRequestModel.PublicDate,
                CreateDate = DateTime.Now
            };
            return await _bookRepository.SaveAsync(book);
      
        }
    }
}
