using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Banking.Accounts.Extensions
{
    public static class Extensions
    {
        public static IEnumerable<object> GetRequiredServices(this IServiceProvider provider, Type serviceType)
        {
            return (IEnumerable<object>)provider.GetRequiredService(typeof(IEnumerable<>).MakeGenericType(serviceType));
        }
    }
}
