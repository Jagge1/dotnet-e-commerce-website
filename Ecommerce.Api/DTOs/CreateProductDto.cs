using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Api.DTOs
{
    public class CreateProductDto
    {
        [Required, StringLength(150)]
        public string Name { get; set; } = String.Empty;

        [Required, StringLength(5000)]
        public string Description { get; set; } = String.Empty;

        // Uses decimal point for price regardless of regional settings
        [Range(typeof(decimal), "0.01", "9999999", ParseLimitsInInvariantCulture = true)]
        public decimal Price { get; set; }

        [Required, Url]
        public string ImageUrl { get; set; } = String.Empty;

        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
    }
}
