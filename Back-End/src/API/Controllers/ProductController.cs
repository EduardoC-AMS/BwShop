using Domain.Core.Data;
using Domain.Models.CategoryModel;
using Domain.Models.ProductModel;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _uow;

        public ProductController(IProductRepository productRepository, IUnitOfWork uow)
        {
            _productRepository = productRepository;
            _uow = uow;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductViewModel request)
        {
            if (request == null)
            {
                return BadRequest("O objeto de solicitação é nulo");
            }

            var product = new Product
            {
                 Id = Guid.NewGuid(),
                 Name = request.Name,
                 Description = request.Description,
                 IdCategory = request.IdCategory,
                 urlImage = request.urlImage,
                 Amount = request.Amount,
                 Price = request.Price,

            };

            _productRepository.Add(product);

            var response = new ProductViewModel
            {
                 Name = request.Name,
                 Description = request.Description,
                 IdCategory = request.IdCategory,
                 urlImage = request.urlImage,
                 Amount = request.Amount,
                 Price = request.Price,
            };

            await _uow.SaveChangesAsync();
            return Ok(response);
        }

        [HttpGet("{productId}")]
        public IActionResult GetById(Guid productId)
        {
            var entity = _productRepository.GetById(productId);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

          [HttpGet]
        public async Task<IActionResult> GetAllproducts()
        {
            var Products = _productRepository.GetAll();

            if (Products == null)
            {
                return NotFound("Nenhum palno de empréstimo cadatrado");
            }

            return Ok(Products);
        }

       [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductViewModel request)
        {

            var entity = _productRepository.GetById(request.Id);

            if (request.Id != entity.Id)
            {
                return BadRequest();
            }

            if (entity == null) return NotFound();



                 entity.Name = request.Name;
                 entity.Description = request.Description;
                 entity.IdCategory = request.IdCategory;
                 entity.urlImage = request.urlImage;
                 entity.Amount = request.Amount;
                 entity.Price = request.Price;
            
            _productRepository.Update(entity);
            await _uow.SaveChangesAsync();
            return Ok(entity);
        }

        [HttpDelete("{productId}")]

        public async Task<IActionResult> Delete(Guid productId)
        {
            var entity = _productRepository.GetById(productId);

            if (entity == null)
            {
                return BadRequest();
            }

            _productRepository.Delete(entity);
            await _uow.SaveChangesAsync();
            return Ok(entity);
        }

    }
}