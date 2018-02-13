using System.Reflection;
using Business.Accounts.Mappers;
using Business.Accounts.Models;
using Business.Accounts.Queries;
using Domain.Accounts;
using Highway.Data;
using Mapping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SimpleIdGenerator;

namespace CrossCuttingConcerns
{
    public static class Extensions
    {
        public static IServiceCollection AddBankingAccountsApplication(this IServiceCollection services)
        {
            services
                .AddMediator()
                .AddMapper()
                .AddPersistence()
                .AddIdGenerator()
                .AddDomain();

            return services;
        }

        private static IServiceCollection AddIdGenerator(this IServiceCollection services)
        {
            services.AddSingleton<IdGenerator>();

            return services;
        }

        private static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddSingleton<IAccountFactory, AccountFactory>();

            return services;
        }

        private static IServiceCollection AddMediator(this IServiceCollection services)
        {
            var business = Assembly.GetAssembly(typeof(GetAccountHandler));

            services.AddMediatR(business);

            return services;
        }

        private static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddScoped<IMapper<Account, AccountModel>, AccountMapper>();

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            var repo = new Repository(new InMemoryDataContext());

            services.AddSingleton<IRepository>(repo);
            services.AddSingleton<IReadOnlyRepository>(repo);
            services.AddSingleton(repo.UnitOfWork);

            return services;
        }
    }
}
