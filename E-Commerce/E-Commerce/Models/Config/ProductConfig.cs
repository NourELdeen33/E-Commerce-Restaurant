using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Models.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasColumnType("VARCHAR")
                .HasMaxLength(200);

            builder.Property(x=>x.ImageUrl)
                .HasColumnType("VARCHAR")
                .HasMaxLength(200);


            builder.Property(x => x.Price)
                .HasPrecision(18, 2);


            builder.HasMany(x => x.ProductIngerdients)
               .WithOne(x => x.Product)
               .HasForeignKey(x => x.Product_Id);

            builder.HasData(
                new Product
 {
     Id = 1,
     Name = "Koshary",
     Description = "A mix of rice, pasta, and lentils, topped with tomato sauce and crispy fried onions.",
     Price = 65.00m,
     Stock = 50,
     CategoryId = 2 // Main Dishes
 },
            
                // International Dishes
                new Product
    {
        Id = 2,
        Name = "Cheeseburger",
        Description = "A classic beef patty with cheese, lettuce, and tomato on a toasted bun.",
        Price = 95.00m,
        Stock = 80,
        CategoryId = 2 // Main Dishes
    },
                new Product
    {
        Id = 3,
        Name = "Grilled Chicken",
        Description = "Marinated grilled chicken breast served with a side of mixed vegetables.",
        Price = 130.00m,
        Stock = 45,
        CategoryId = 2 // Main Dishes
    },
            
                // Appetizer (CategoryId = 1)
                new Product
    {
        Id = 4,
        Name = "Caesar Salad",
        Description = "Crisp romaine lettuce, croutons, and Parmesan cheese with Caesar dressing.",
        Price = 55.00m,
        Stock = 60,
        CategoryId = 1 // Appetizers
    },
            
                // Dessert (CategoryId = 3)
                new Product
    {
        Id = 5,
        Name = "Chocolate Cake",
        Description = "Rich, decadent chocolate layer cake.",
        Price = 50.00m,
        Stock = 35,
        CategoryId = 3
    }// Desserts               
                );


        }
    }
}
