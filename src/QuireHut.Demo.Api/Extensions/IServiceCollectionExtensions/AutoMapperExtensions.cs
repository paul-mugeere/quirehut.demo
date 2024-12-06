using AutoMapper;
using QuireHut.Demo.Application.Books.Mappers.MappingProfiles;

namespace QuireHut.Demo.Api.Extensions.IServiceCollectionExtensions;

public static class AutoMapperExtensions
{
    public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddMaps(typeof(BookMappingProfile).Assembly);
            cfg.AddMaps(typeof(Program).Assembly);
        });
        return services;
    }
}