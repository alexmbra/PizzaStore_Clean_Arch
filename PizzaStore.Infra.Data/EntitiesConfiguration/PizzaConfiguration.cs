using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaStore.Domain.Entities;

namespace PizzaStore.Persistence.EntitiesConfiguration;
public class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
{
    public void Configure(EntityTypeBuilder<Pizza> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Price)
            .HasPrecision(10, 2)
            .IsRequired();


        builder.HasData(
            new Pizza(1, "Marguerita", 10.0m),
            new Pizza(2, "Portuguesa", 12.0m),
            new Pizza(3, "Vegana", 13.0m)
        );
    }
}
