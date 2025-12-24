using E_Commerce.Data;

namespace E_Commerce.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // -----------------------------------------//
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        // -----------------------------------------//

        public ICollection<OrderItem>? OrderItems { get; set; } 
    }
}
