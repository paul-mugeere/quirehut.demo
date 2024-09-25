using QuireHut.Demo.Infrastructure;

namespace QuireHut.Demo.Api.Extensions.IServiceCollectionExtensions
{
    internal static class DatabaseExtensions
    {
        internal static IServiceCollection AddDatabaseService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:Default"] ?? throw new Exception("Default connection string is null");
            return services.AddDatabase(connectionString);
        }
    }
}