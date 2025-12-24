namespace E_Commerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } 

        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? ImageUrl { get; set; }

        //----------------------------------------------------//
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        //----------------------------------------------------//
        public ICollection<ProductIngerdient>? ProductIngerdients { get; set; } 
        public ICollection<OrderItem>? OrderItems { get; set; } 
    }
}
