using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace QuireHut.Demo.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwaggerDocs(this SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "QuireHut Demo Api",
                Description = "An API for the quirehut demo app",
            });
        }

        public static void AddSecurityBearerRequirement(this SwaggerGenOptions options, string securityDefinitionId, IConfiguration configuration)
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

        public static void AddOauth2SecurityRequirement(this SwaggerGenOptions options, string securityDefinitionId, IConfiguration configuration)
        {
            options.AddSecurityDefinition(securityDefinitionId, new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Implicit = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri(configuration["Auth:AuthEndpoint"]),
                        Scopes = new Dictionary<string, string>
                        {
                            { "api", "Access to the API" }
                        }
                    }
                },
                Name = "Authorization",
                Description = "JWT Authorization using the OAuth2 scheme.",
                In = ParameterLocation.Header
            });

            options.AddSecurityRequirementOfSecurityDefinitionId(securityDefinitionId);
        }


        public static WebApplication UseSwaggerDocs(this WebApplication app)
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
            return app;
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
                    new string[] { "api" }
                }
            });
        }
    }
}