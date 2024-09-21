using QuireHut.Demo.Application;
using QuireHut.Demo.Domain;
using QuireHut.Demo.Infrastructure;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using QuireHut.Demo.Api.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace QuireHut.Demo.Api;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR();
        services.AddApplicationServices();
        services.AddSwaggerDocs(configuration);
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionStrings:Default"] ?? throw new Exception("Default connection string is null");
        return services.AddDatabase(connectionString);
    }

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(jwtBearerOpt =>
        {
            jwtBearerOpt.Audience = configuration["Auth:Audience"];
            jwtBearerOpt.Authority = configuration["Auth:AuthEndpoint"];
            jwtBearerOpt.MetadataAddress = configuration["Auth:MetadataAddress"];

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                jwtBearerOpt.RequireHttpsMetadata = false; //only for development purpose

            jwtBearerOpt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = configuration["Auth:Issuer"],
                ValidAudience = configuration["Auth:Audience"],
                ValidateAudience = true, 
                ValidateIssuer = true
               
            };
        });
        return services;
    }

    private static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IBookService, BookService>();
        services.AddTransient<IBookRepository, BookRepository>();
    }

    private static void AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(CreateBookCommand).Assembly);
        });
    }

    private static void AddSwaggerDocs(this IServiceCollection services, IConfiguration configuration)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        // services.AddEndpointsApiExplorer(); // Not using minimal apis
        services.AddSwaggerGen(SwaggerGenConfig(configuration));
    }

    //ToDo: Move to SwaggerExtensinos
    private static Action<SwaggerGenOptions> SwaggerGenConfig(IConfiguration configuration)
    {
        return options =>
        {
            options.AddSwaggerDocs();
            options.AddSecurityBearerRequirement("Bearer",configuration);
            options.AddOauth2SecurityRequirement("oauth2",configuration);
        };
    }
}
