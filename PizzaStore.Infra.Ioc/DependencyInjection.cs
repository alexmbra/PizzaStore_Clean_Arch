using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaStore.Application.Interfaces;
using PizzaStore.Application.Mappings;
using PizzaStore.Application.Services;
using PizzaStore.Domain.Interfaces;
using PizzaStore.Persistence.Context;
using PizzaStore.Persistence.Repositories;

namespace PizzaStore.Infra.IoC;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext)
            .Assembly.FullName)));

        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IPizzaService, PizzaService>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IPizzaRepository, PizzaRepository>();
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;
    }
}
