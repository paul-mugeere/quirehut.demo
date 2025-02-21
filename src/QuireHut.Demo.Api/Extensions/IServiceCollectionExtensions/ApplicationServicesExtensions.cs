using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Domain.Books.Repositories;
using QuireHut.Demo.Domain.Persons.Repositories;
using QuireHut.Demo.Infrastructure.Persistence.Books;
using QuireHut.Demo.Infrastructure.Persistence.Persons;
using GetBooksQueryHandler = QuireHut.Demo.Infrastructure.Persistence.Books.QueryHandlers.GetBooksQueryHandler;

namespace QuireHut.Demo.Api.Extensions.IServiceCollectionExtensions
{
    internal static class ApplicationServicesExtensions
    {
        internal static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // services.AddTransient<IGetBooksQueryHandler, GetBooksQueryHandler>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            return services;
        }
    }
}