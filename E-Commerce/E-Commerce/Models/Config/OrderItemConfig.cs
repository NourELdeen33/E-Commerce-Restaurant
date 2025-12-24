using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Models.Config
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.OrderItemId);

            builder.HasOne(x=>x.Order)
                .WithMany(x=>x.OrderItems)
                .HasForeignKey(x=>x.OrderId);



            builder.HasOne(x=>x.Product)
                .WithMany(x=>x.OrderItems)
                .HasForeignKey(x=>x.ProductId);
        }
    }
}
