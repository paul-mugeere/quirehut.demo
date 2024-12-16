using QuireHut.Demo.Application.Books.Commands;

namespace QuireHut.Demo.Api.Extensions.IServiceCollectionExtensions
{
    internal static class MediatRExtensions
    {
        internal static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateBookCommand).Assembly);
            });
            return services;
        }
    }
}