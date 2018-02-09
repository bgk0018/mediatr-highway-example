using System.Reflection;
using Business.Accounts.Queries;
using Domain.Accounts;
using Microsoft.Extensions.DependencyInjection;
using SimpleIdGenerator;

namespace CrossCuttingConcerns.Registry
{
    public static class ApplicationRegistry
    {
        public static void Register(IServiceCollection services)
        {
            FluentValidatorRegistry.Register(services);
            HighwayDataRegistry.Register(services);
            MediatrRegistry.Register(services);

            var business = Assembly.GetAssembly(typeof(GetAccountHandler));
            var domain = Assembly.GetAssembly(typeof(Account));

            services.AddSingleton<IdGenerator>();
            services.Scan(p => p.FromAssemblies(business, domain).AddClasses().AsMatchingInterface());
        }
    }
}
