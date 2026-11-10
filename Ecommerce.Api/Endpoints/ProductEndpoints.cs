using Ecommerce.Api.Services;

namespace Ecommerce.Api.Endpoints
{
    public class ProductEndpoints
    {
        public static void Map(WebApplication app)
        {
            var group = app.MapGroup("/api/products").WithTags("products");

            group.MapGet("", async (ProductService productService, CancellationToken cancellationToken) =>
            {
                var products = await productService.GetAllProductsAsync(cancellationToken);
                return Results.Ok(products);
            });   
        
        }
    }
}
