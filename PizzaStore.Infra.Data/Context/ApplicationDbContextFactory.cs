using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PizzaStore.Persistence.Context;

namespace PizzaStore.Infra.Data.Context;
public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
       var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer("Server=DESKTOP-NRDKSHP\\SQLEXPRESS;Database=PizzaStoreDB;Trusted_Connection=True;TrustServerCertificate=True;");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
