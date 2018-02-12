using Business.Accounts.Commands;
using Business.Accounts.Commands.CreateTransfer;
using Business.Accounts.Queries;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;

namespace CrossCuttingConcerns.Registry
{
    public static class FluentValidatorRegistry
    {
        internal static void Register(IServiceCollection services)
        {
            services.Scan(p =>
            {
                p.FromAssemblyOf<CreateAccountCommand>()
                    .AddClasses(q => q.AssignableTo(typeof(IValidator<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
            });
        }
    }
}
