using Ecommerce.Api.Data;
using Ecommerce.Api.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Services
{
    public class ProductService(AppDbContext db)
    {
        // Uses cancellation token to allow query to be cancelled if the request is aborted.
        public async Task<List<ProductDto>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            var products = await db.Products
                .OrderBy(product => product.Id)
                .Select(product => new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    StockQuantity = product.StockQuantity,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category.Name,
                }).ToListAsync(cancellationToken);

            return products;
        }
    }
}
