
using Microsoft.Extensions.Configuration;
using MMLib.SwaggerForOcelot.Middleware;

namespace OcelotApiGateway.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddOcelotAuthService(this IServiceCollection services, IConfiguration configuration)
        {
            var identityUrl = configuration.GetValue<string>("IdentityUrl");
            var authenticationProviderKey = "IdentityApiKey";
            //…
            services.AddAuthentication()
                .AddJwtBearer(authenticationProviderKey, x =>
                {
                    x.Authority = identityUrl;
                    x.RequireHttpsMetadata = false;
                    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidAudiences = new[] { "orders", "basket", "locations", "marketing", "mobileshoppingagg", "webshoppingagg" }
                    };
                });
            //...
            return services; 
        }

        public static IServiceCollection AddSwaggerForOcelotService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerForOcelot(configuration);
           
            return services;
        }
    }
}
