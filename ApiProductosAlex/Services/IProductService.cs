using ApiProductosAlex.Entities;

namespace ApiProductosAlex.Services
{
    public interface IProductService
    {
        Task<(IEnumerable<Product> Products, int TotalCount)> GetAllAsync(int pageNumber, int pageSize, string? name, string? category);
        Task<Product?> GetByIdAsync(int id);
    }
}
