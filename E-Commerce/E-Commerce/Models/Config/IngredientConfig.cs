using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Models.Config
{
    public class IngredientConfig : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasColumnType("VARCHAR")
                .HasMaxLength(200);


            builder.HasMany(x => x.ProductIngerdients)
                .WithOne(x => x.Ingredient)
                .HasForeignKey(x => x.Ingerdient_Id);

            builder.HasData(
                new Ingredient { Id = 1, Name = "Rice" },
                new Ingredient { Id = 2, Name = "Pasta" },
                new Ingredient { Id = 3, Name = "Lentils" },
                new Ingredient { Id = 4, Name = "Onion" },
                new Ingredient { Id = 5, Name = "Tomato" },
                new Ingredient { Id = 6, Name = "Lamb Meat" },
                new Ingredient { Id = 7, Name = "Chicken" },
                new Ingredient { Id = 8, Name = "Cumin" },
                new Ingredient { Id = 9, Name = "Garlic" },
                new Ingredient { Id = 10, Name = "Eggplant" },
                new Ingredient { Id = 11, Name = "Pastry Dough" },
                new Ingredient { Id = 12, Name = "Milk" },
                new Ingredient { Id = 13, Name = "Flour" },
                new Ingredient { Id = 14, Name = "Cocoa Powder" },
                new Ingredient { Id = 15, Name = "Sugar" });
        }
    }
}
