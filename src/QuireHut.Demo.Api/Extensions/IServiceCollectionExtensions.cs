using QuireHut.Demo.Application;
using QuireHut.Demo.Domain;
using QuireHut.Demo.Infrastructure;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace QuireHut.Demo.Api;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddMediatR();
        services.AddApplicationServices();
        services.AddSwaggerDocs();
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionStrings:Default"] ?? throw new Exception("Default connection string is null");
        return services.AddDatabase(connectionString);
    }

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options => {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(jwtBearerOpt =>{
            jwtBearerOpt.Audience = configuration["Auth:Audience"];
            jwtBearerOpt.Authority = configuration["Auth:Endpoint"];
            jwtBearerOpt.RequireHttpsMetadata = false; //only for development purpose
            jwtBearerOpt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                // ValidIssuer = configuration["Auth:Issuer"],
                // ValidAudience = configuration["Auth:Audience"],
                // IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Auth:SigningKey"])),
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

    private static void AddSwaggerDocs(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        // services.AddEndpointsApiExplorer(); // Not using minimal apis
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Library Api",
                Description = "An API for the library app",
            });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme.",
            });
        });
    }
}
