using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Banking.Accounts.Extensions
{
    public static class Extensions
    {
        internal static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Banking.Accounts", Version = "v1" });
            });

            services.AddMvc();

            return services;
        }
    }
}
