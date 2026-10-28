namespace Ecommerce.Api.Models;

public class Cart
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public User User { get; set; } = null!;

    public List<CartItem> Items { get; set; } = [];
}
