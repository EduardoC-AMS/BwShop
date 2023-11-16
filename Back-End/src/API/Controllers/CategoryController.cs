using Domain.Core.Data;
using Domain.Models.CategoryModel;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _uow;

        public CategoryController(ICategoryRepository categoryRepository, IUnitOfWork uow)
        {
            _categoryRepository = categoryRepository;
            _uow = uow;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryViewModel request)
        {
            if (request == null)
            {
                return BadRequest("O objeto de solicitação é nulo");
            }

            var category = new Category
            {
                 Id = Guid.NewGuid(),
                 Description = request.Description,
                 IsActive = request.IsActive,
            };

            _categoryRepository.Add(category);

            var response = new CategoryViewModel
            {
                Description = category.Description,
                IsActive = category.IsActive,
            };

            await _uow.SaveChangesAsync();
            return Ok(response);
        }

        [HttpGet("{CategoryId}")]
        public IActionResult GetById(Guid CategoryId)
        {
            var entity = _categoryRepository.GetById(CategoryId);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

          [HttpGet]
        public async Task<IActionResult> GetAllCategorys()
        {
            var categories = _categoryRepository.GetAll();

            if (categories == null)
            {
                return NotFound("Nenhum palno de empréstimo cadatrado");
            }

            return Ok(categories);
        }

       [HttpPut]
        public async Task<IActionResult> Put([FromBody] CategoryViewModel request)
        {

            var entity = _categoryRepository.GetById(request.Id);

            if (request.Id != entity.Id)
            {
                return BadRequest();
            }

            if (entity == null) return NotFound();



            entity.Description = request.Description;
            entity.IsActive = request.IsActive;
            
            _categoryRepository.Update(entity);
            await _uow.SaveChangesAsync();
            return Ok(entity);
        }

        [HttpDelete("{CategoryId}")]

        public async Task<IActionResult> Delete(Guid CategoryId)
        {
            var entity = _categoryRepository.GetById(CategoryId);

            if (entity == null)
            {
                return BadRequest();
            }

            _categoryRepository.Delete(entity);
            await _uow.SaveChangesAsync();
            return Ok(entity);
        }

    }
}