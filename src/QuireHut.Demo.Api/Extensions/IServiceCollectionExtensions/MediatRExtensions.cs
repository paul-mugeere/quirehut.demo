using QuireHut.Demo.Application.Books.Commands;
using QuireHut.Demo.Infrastructure.Persistence.Books.QueryHandlers;

namespace QuireHut.Demo.Api.Extensions.IServiceCollectionExtensions
{
    internal static class MediatRExtensions
    {
        internal static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateBookCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetBooksQueryHandler).Assembly);
            });
            return services;
        }
    }
}