using ApiProductosAlex.Data;
using ApiProductosAlex.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiProductosAlex.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Product> Products, int TotalCount)> GetAllAsync(int pageNumber, int pageSize, string? name, string? category)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(p => p.Name.Contains(name.Trim()));
            if (!string.IsNullOrWhiteSpace(category))
                query = query.Where(p => p.Category.Contains(category.Trim()));

            int totalCount = await query.CountAsync();
            var products = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (products, totalCount);
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
