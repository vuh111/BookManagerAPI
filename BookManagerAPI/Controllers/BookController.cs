
using BookManagerBUS.AuthorBusiness;
using BookManagerBUS.BookBusiness;
using BookManagerBUS.CategoryBusiness;
using BookManagerBUS.Extensions;
using BookManagerBUS.QueryModel;
using BookManagerBUS.RequestModel;
using BookManagerEntities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace BookManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IAutherService _authorService;
        private readonly ICategoryService _categoryService;
        public BookController(IBookService bookService,IAutherService autherService,ICategoryService categoryService)
        {
            _bookService = bookService;
            _authorService = autherService;
            _categoryService= categoryService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll(
            [FromQuery] int? page,
            [FromQuery] int? size,

            [FromQuery] string? filter="" )
        {
            BookQueryModel filterObject = new BookQueryModel();

            if (page.HasValue) filterObject.CurrentPage = page.Value;
            if (size.HasValue) filterObject.PageSize = size.Value;
            if(!String.IsNullOrEmpty(filter)) filterObject.Filter = filter;

            try
            {
                var result = await _bookService.GetAllAsync(filterObject);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
           try
            {
                return Ok(await _bookService.GetAsync(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] BookRequestModel model)
        {
            try
            {
                return Ok(await _bookService.SaveAsync(model,Guid.Empty));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(
            [FromQuery] Guid id,
            [FromBody] BookRequestModel model)
        {
            try
            {
                return Ok(await _bookService.SaveAsync(model,id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                
                return Ok(await _bookService.DeleteAsync(id));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
