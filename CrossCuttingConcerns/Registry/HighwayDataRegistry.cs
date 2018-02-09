using Highway.Data;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCuttingConcerns.Registry
{
    public static class HighwayDataRegistry
    {
        internal static void Register(IServiceCollection services)
        {
            var repo = new Repository(new InMemoryDataContext());

            services.AddSingleton<IRepository>(repo);
            services.AddSingleton<IReadOnlyRepository>(repo);
            services.AddSingleton(repo.UnitOfWork);
        }
    }
}
