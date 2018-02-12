using System.Reflection;
using Business.Accounts.Mappers;
using Business.Accounts.Models;
using Business.Accounts.Queries;
using CrossCuttingConcerns.Behaviors;
using Domain.Accounts;
using Highway.Data;
using Mapping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

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
                .AddValidation();

            return services;
        }

        private static IServiceCollection AddMediator(this IServiceCollection services)
        {
            var crossCutting = Assembly.GetAssembly(typeof(ValidationBehavior<,>));
            var business = Assembly.GetAssembly(typeof(GetAccountHandler));

            ////TODO might need
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddMediatR(crossCutting, business);

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

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            //services.Scan(p =>
            //{
            //    p.FromAssemblyOf<CreateAccountCommand>()
            //        .AddClasses(q => q.AssignableTo(typeof(IValidator<>)))
            //        .AsImplementedInterfaces()
            //        .WithTransientLifetime();
            //});


            return services;
        }
    }
}
