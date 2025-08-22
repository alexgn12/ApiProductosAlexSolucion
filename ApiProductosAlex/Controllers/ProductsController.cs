using ApiProductosAlex.Entities;
using ApiProductosAlex.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiProductosAlex.Controllers
{
    [ApiController]
    [Route("api/Products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string? name = null, [FromQuery] string? category = null)
        {
            _logger.LogInformation("Obteniendo productos. Página: {PageNumber}, Tamaño: {PageSize}, Filtro nombre: {Name}, Filtro categoría: {Category}", pageNumber, pageSize, name, category);
            var (products, totalCount) = await _productService.GetAllAsync(pageNumber, pageSize, name, category);
            return Ok(new { totalCount, products });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Obteniendo producto por ID: {Id}", id);
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                _logger.LogWarning("Producto no encontrado con ID: {Id}", id);
                return NotFound();
            }
            return Ok(product);
        }
    }
}
