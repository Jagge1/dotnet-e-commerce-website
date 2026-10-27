using Ecommerce.Api.Models.Enums;

namespace Ecommerce.Api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public OrderStatus Status { get; set; } = OrderStatus.PENDINGPAYMENT;
        public string? StripeCheckoutStatus { get; set; }

        public List<OrderItem> Items { get; set; } = [];
    }
}
