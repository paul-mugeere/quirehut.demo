using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Books.Queries.Services;
using QuireHut.Demo.Domain.Books.Repositories;
using QuireHut.Demo.Domain.Persons.Repositories;
using QuireHut.Demo.Infrastructure.Persistence.Books;
using QuireHut.Demo.Infrastructure.Persistence.Persons;
using GetBooksQueryHandler = QuireHut.Demo.Application.Books.Queries.QueryHandlers.GetBooksQueryHandler;

namespace QuireHut.Demo.Api.Extensions.IServiceCollectionExtensions
{
    internal static class ApplicationServicesExtensions
    {
        internal static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IBookQueryService, BookQueryService>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            return services;
        }
    }
}