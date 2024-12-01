
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuireHut.Demo.Infrastructure.Persistence;

namespace QuireHut.Demo.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        return services.AddDbContextFactory<LibraryDemoDbContext>(options =>
        {
            options.UseNpgsql(
                connectionString, 
                npsqlOptions => npsqlOptions.MigrationsAssembly(typeof(LibraryDemoDbContext).Assembly.GetName().Name))
                .UseSnakeCaseNamingConvention();
        });
    }
}
