using BookManagerBUS.AuthorBusiness;
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
    public class AuthorController : ControllerBase
    {
        private readonly IAutherService _authorService;

        public AuthorController(IAutherService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll(
            [FromQuery] int? page,
            [FromQuery] int? size)
        {
            AuthorQueryModel filterObject = new AuthorQueryModel();

            if(page.HasValue) filterObject.CurrentPage= page.Value;
            if(size.HasValue) filterObject.PageSize= size.Value;
            try
            {
                var result = await _authorService.GetAllAsync(filterObject);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _authorService.GetAsync(id));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create (
            [FromBody] AuthorRequestModel authorRequestModel)
        {
            var author = new Author() {
                Brithday= authorRequestModel.Brithday,
                Name= authorRequestModel.Name,
                National= authorRequestModel.National,
            };
            try
            {
                return Ok(await _authorService.SaveAsync(author));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            [FromBody] AuthorRequestModel authorRequestModel,
            [FromQuery] Guid id)
        {
            var author = new Author()
            {
                Id = id,
                Name = authorRequestModel.Name,
                National = authorRequestModel.National,
                Brithday = authorRequestModel.Brithday,
            };
           try
            {
                return Ok(await _authorService.SaveAsync(author));
            }
           catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult>Delete(
            [FromQuery] Guid id)
        {
            try
            {
                return Ok(await _authorService.DeleteAsync(id));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
