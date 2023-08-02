using BookManagerBUS.CategoryBusiness;
using BookManagerBUS.Extensions;
using BookManagerBUS.QueryModel;
using BookManagerBUS.RequestModel;
using BookManagerDAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("")]
        public async Task<Pagination<Category>>Getall(
            [FromQuery] int? page,
            [FromQuery] int? size)
        {
            CategoryQueryModel filterObject = new CategoryQueryModel();
            if (page.HasValue) filterObject.CurrentPage = page.Value;
            if (size.HasValue) filterObject.PageSize = size.Value;
            var result = await _categoryService.GetAllAsync(filterObject);
            return result;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _categoryService.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CategoryRequestModel  categoryRequestModel)
        {
            var category = new Category() {
                CategoryName= categoryRequestModel.CategoryName,
                Code= categoryRequestModel.Code,
                Description= categoryRequestModel.Description
            };
            try
            {
                return Ok(await _categoryService.SaveAsync(category));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            [FromBody] CategoryRequestModel categoryRequestModel,
            [FromQuery] Guid id)
        {
            var category = new Category()
            {
                Id = id,
                CategoryName = categoryRequestModel.CategoryName,
                Code = categoryRequestModel.Code,
                Description = categoryRequestModel.Description
            };
            try
            {
                return Ok(await _categoryService.SaveAsync(category));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(
            [FromQuery] Guid id)
        {
            try
            {
                return Ok(await _categoryService.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
