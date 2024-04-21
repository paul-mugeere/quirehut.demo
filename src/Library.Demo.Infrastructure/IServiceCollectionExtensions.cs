using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Demo.Infrastructure;

public static class IServiceCollectionExtensions{
    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString){
        return services.AddDbContextFactory<LibraryDemoDbContext>(options=>{
            options.UseNpgsql(connectionString,npsqlOptions=>{
                npsqlOptions.MigrationsAssembly(typeof(LibraryDemoDbContext).Assembly.GetName().Name);             
            });
        });
    }
}
