using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaStore.Domain.Entities;

namespace PizzaStore.Infra.Data.EntitiesConfiguration;
public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(oi => oi.Id);

        // Relationships with PizzaForOrderItem
        // Relationships with PizzaForOrderItem
        builder
            .HasOne(o => o.Pizza)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(o => o.PizzaId);



    }
}
