using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace QuireHut.Demo.Api.Extensions.IServiceCollectionExtensions;

internal static class AuthenticationExtensions
{
    internal static IServiceCollection AddJwtAuthentication(this IServiceCollection services, AuthenticationOptions authenticationOptions)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(ConfigureJwtBearerOptions(authenticationOptions));
        return services;
    }

    private static Action<JwtBearerOptions> ConfigureJwtBearerOptions(AuthenticationOptions authOptions)
    {
        return jwtBearerOpt =>
        {
            jwtBearerOpt.Audience = authOptions.Schemes.Bearer.Audience;
            jwtBearerOpt.Authority = authOptions.Schemes.Bearer.Issuer;
            jwtBearerOpt.MetadataAddress = authOptions.Schemes.Bearer.MetadataAddress;
            jwtBearerOpt.RequireHttpsMetadata = !IsDevelopmentEnv();

            jwtBearerOpt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = authOptions?.Schemes.Bearer.Issuer,
                ValidAudience = authOptions?.Schemes.Bearer.Audience,
                ValidateAudience = true,
                ValidateIssuer = true
            };
        };
    }

    private static bool IsDevelopmentEnv()
    {
        return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
    }
}