using QuireHut.Demo.Application.Books.Mappers;
using QuireHut.Demo.Domain.Books.Repositories;
using QuireHut.Demo.Domain.Persons.Repositories;
using QuireHut.Demo.Infrastructure.Persistence.Repositories;

namespace QuireHut.Demo.Api.Extensions.IServiceCollectionExtensions
{
    internal static class ApplicationServicesExtensions
    {
        internal static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IBookMapper, BookMapper>();
            services.AddTransient<IBookAuthorMapper, BookAuthorMapper>();
            services.AddTransient<IBookTitleMapper, BookTitleMapper>();
            return services;
        }
    }
}