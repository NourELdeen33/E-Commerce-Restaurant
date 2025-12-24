using System.Reflection.Emit;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Models.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasColumnType("VARCHAR")
                .HasMaxLength(200);



            builder.HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
            builder.HasData(
                      new Category { Id = 1, Name = "Appetizers" },
                      new Category { Id = 2, Name = "Main Dishes" },
                      new Category { Id = 3, Name = "Desserts" },
                      new Category { Id = 4, Name = "Beverages" }
                            );
        }
    }
}
