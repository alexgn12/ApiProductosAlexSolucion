using ApiProductosAlex.Entities;
using Bogus;

namespace ApiProductosAlex.Seeding
{
    public class ProductSeeder
    {
        private static readonly string[] Categories = new[]
        {
            "Electrónica", "Hogar", "Juguetes", "Ropa", "Libros"
        };

        public static List<Product> GenerateProducts(int count = 100)
        {
            var faker = new Faker<Product>()
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Category, f => f.PickRandom(Categories))
                .RuleFor(p => p.Price, f => f.Random.Decimal(1, 1000))
                .RuleFor(p => p.Stock, f => f.Random.Int(0, 500))
                .RuleFor(p => p.CreatedDate, f => f.Date.Past(2));

            return faker.Generate(count);
        }
    }
}
