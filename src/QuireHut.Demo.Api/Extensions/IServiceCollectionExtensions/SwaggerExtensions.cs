using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.OpenApi.Models;
using QuireHut.Demo.Api.Configurations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace QuireHut.Demo.Api.Extensions.IServiceCollectionExtensions
{
    internal static class SwaggerExtensions
    {
        internal static void AddSwaggerDocs(this IServiceCollection services, AuthenticationOptions authenticationOptions)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            // services.AddEndpointsApiExplorer(); // Not using minimal apis
            services.AddSwaggerGen(SwaggerGenConfig(authenticationOptions));
        }

        internal static void UseSwaggerDocs(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }
        }

        private static Action<SwaggerGenOptions> SwaggerGenConfig(AuthenticationOptions authenticationOptions)
        {
            return options =>
            {
                options.AddSwaggerDocs();
                options.AddSecurityBearerRequirement("Bearer");
                options.AddOauth2SecurityRequirement("oauth2", authenticationOptions.Schemes.Bearer.AuthEndpoint);
                options.TagActionsBy(c=>{
                    return new List<string> { c.HttpMethod};
                });
            };
        }

        private static void AddSwaggerDocs(this SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "QuireHut Demo Api",
                Description = "An API for the quirehut demo app",
            });
        }

        private static void AddSecurityBearerRequirement(this SwaggerGenOptions options, string securityDefinitionId)
        {
            options.AddSecurityDefinition(securityDefinitionId, new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Description = "JWT Authorization using the Bearer scheme.",
                In = ParameterLocation.Header
            });

            options.AddSecurityRequirementOfSecurityDefinitionId(securityDefinitionId);
        }

        private static void AddOauth2SecurityRequirement(this SwaggerGenOptions options, string securityDefinitionId, string authUrl)
        {
            options.AddSecurityDefinition(securityDefinitionId, new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Implicit = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri(authUrl),
                        Scopes = new Dictionary<string, string>
                        {
                            { "api_access", "Access to the API" }
                        }
                    }
                },
                Name = "Authorization",
                Description = "JWT Authorization using the OAuth2 scheme.",
                In = ParameterLocation.Header
            });

            options.AddSecurityRequirementOfSecurityDefinitionId(securityDefinitionId);
        }

        private static void AddSecurityRequirementOfSecurityDefinitionId(this SwaggerGenOptions options, string securityDefinitionId)
        {
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = securityDefinitionId
                        }
                    },
                    new string[] { "api_access" }
                }
            });
        }
    }
}