using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Banking.Accounts
{
    public static class ApiRegistry
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Banking.Accounts", Version = "v1" });
            });
            services.AddMvc();
        }
    }
}
