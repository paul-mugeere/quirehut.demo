using QuireHut.Demo.Application;
using QuireHut.Demo.Domain;
using QuireHut.Demo.Infrastructure;

namespace QuireHut.Demo.Api.Extensions.IServiceCollectionExtensions
{
    internal static class ApplicationServicesExtensions
    {
        internal static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IBookRepository, BookRepository>();
            return services;
        }
    }
}