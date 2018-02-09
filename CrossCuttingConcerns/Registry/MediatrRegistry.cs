using System.Reflection;
using Business.Accounts.Queries;
using CrossCuttingConcerns.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCuttingConcerns.Registry
{
    public static class MediatrRegistry
    {
        internal static void Register(IServiceCollection services)
        {
            var crossCutting = Assembly.GetAssembly(typeof(ValidationBehavior<,>));
            var business = Assembly.GetAssembly(typeof(GetAccountHandler));

            //TODO might need
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddMediatR(crossCutting, business);
        }
    }
}
