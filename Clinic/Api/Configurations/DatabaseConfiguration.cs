using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Configurations;

public static class DatabaseConfiguration
{

    public static void AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        );
    }


    public static void UseDataBaseConfiguration(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetService<DataContext>();
        context.Database.Migrate();
        context.Database.EnsureCreated();

    }
}
