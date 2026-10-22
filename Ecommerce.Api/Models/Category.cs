namespace Ecommerce.Api.Models
{
    public class Category
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }


        public List<Product> Products { get; set; } = [];

    }
}
