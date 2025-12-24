namespace E_Commerce.Models
{
    public class ProductIngerdient
    {
        public int Product_Id { get; set; }
        public int Ingerdient_Id { get; set; }
        
        public Product? Product { get; set; } 
        public Ingredient? Ingredient { get; set; } 
    
    
    }
}
