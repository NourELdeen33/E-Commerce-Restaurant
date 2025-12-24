using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Models.Config
{
    public class ProductIngerdientConfig : IEntityTypeConfiguration<ProductIngerdient>
    {
        public void Configure(EntityTypeBuilder<ProductIngerdient> builder)
        {
            builder.HasKey(x => new { x.Product_Id, x.Ingerdient_Id });






            builder.HasData(
    // Koshary (Product Id = 1) Ingredients: Rice (1), Pasta (2), Lentils (3), Onion (4), Tomato (5)
    new ProductIngerdient { Ingerdient_Id = 1, Product_Id = 1 },
    new ProductIngerdient { Ingerdient_Id = 1, Product_Id = 2 },
    new ProductIngerdient { Ingerdient_Id = 1, Product_Id = 3 },
    new ProductIngerdient { Ingerdient_Id = 1, Product_Id = 4 },
    new ProductIngerdient { Ingerdient_Id = 1, Product_Id = 5 },

    // Cheeseburger (Product Id = 2) Ingredients: Beef Patty (6), Lettuce (10), Tomato (5), Cheese (12)
    new ProductIngerdient { Product_Id = 2, Ingerdient_Id = 6 },
    new ProductIngerdient { Product_Id = 2, Ingerdient_Id = 10 },
    new ProductIngerdient { Product_Id = 2, Ingerdient_Id = 5 },
    new ProductIngerdient { Product_Id = 2, Ingerdient_Id = 12 },

    // Grilled Chicken (Product Id = 3) Ingredient: Chicken Breast (7)
    new ProductIngerdient { Product_Id = 3, Ingerdient_Id = 7 },

    // Caesar Salad (Product Id = 4) Ingredients: Lettuce (10), Croutons (11), Bacon (8)
    new ProductIngerdient { Product_Id = 4, Ingerdient_Id = 10 },
    new ProductIngerdient{ Product_Id = 4, Ingerdient_Id = 11 },
    new ProductIngerdient { Product_Id = 4, Ingerdient_Id = 8 },

    // Chocolate Cake (Product Id = 5) has no specific ingredients linked here for simplicity
    new ProductIngerdient{ Product_Id = 5, Ingerdient_Id = 13 },
    new ProductIngerdient{ Product_Id = 5, Ingerdient_Id = 14 },
    new ProductIngerdient { Product_Id = 5, Ingerdient_Id = 15 }
);






        }
    }
}
