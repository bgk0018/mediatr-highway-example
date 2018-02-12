using Business.Accounts.Mappers;
using Business.Accounts.Models;
using Domain.Accounts;
using Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCuttingConcerns.Registry
{
    public static class AutoMapperRegistry
    {
        public static void Register(IServiceCollection services)
        {
            //TODO Actually use Automapper instead

            services.AddScoped<IMapper<Account, AccountModel>, AccountMapper>();
        }
    }
}
