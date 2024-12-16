namespace QuireHut.Demo.Api.Extensions.IServiceCollectionExtensions
{
    internal static class AuthorizationExtensions
    {
        internal static IServiceCollection AddAuthorizationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ManageCustomerOrder", policyBuilder =>
                {
                    policyBuilder.RequireAuthenticatedUser();
                    policyBuilder.RequireAssertion(context =>
                        context.User.IsInRole("customer") || context.User.IsInRole("customer_service")
                    );
                });
            });
            return services;
        }
    }
}