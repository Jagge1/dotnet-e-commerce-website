namespace Ecommerce.Api.Models
{
    public class Product
    {   
        public int Id { get; set; } 
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = String.Empty;
        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

    }
}
