
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuireHut.Demo.Infrastructure.Persistence;

namespace QuireHut.Demo.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        return services.AddDbContextFactory<QuirehutDemoDbContext>(options =>
        {
            options.UseNpgsql(
                connectionString, 
                npSqlOptions => npSqlOptions.MigrationsAssembly(typeof(QuirehutDemoDbContext).Assembly.GetName().Name))
                .UseSnakeCaseNamingConvention();
        });
    }
}
