using QuireHut.Demo.Application.Books.Mappers;
using QuireHut.Demo.Application.Books.Services;
using QuireHut.Demo.Domain.Books.Repositories;
using QuireHut.Demo.Domain.Persons.Repositories;
using QuireHut.Demo.Infrastructure.Persistence.Repositories;
using QuireHut.Demo.Infrastructure.Persistence.Services;

namespace QuireHut.Demo.Api.Extensions.IServiceCollectionExtensions
{
    internal static class ApplicationServicesExtensions
    {
        internal static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IBookQueryService, BooksQueryService>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IBookMapper, BookMapper>();
            services.AddTransient<IBookAuthorMapper, BookAuthorMapper>();
            services.AddTransient<IBookTitleMapper, BookTitleMapper>();
            return services;
        }
    }
}