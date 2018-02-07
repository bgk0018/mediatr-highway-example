using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace CrossCuttingConcern.Registries
{
    public static class RegistryExtensions
    {
        public static void Compose(this IContainer container)
        {
            container.Configure(p =>
            {
                p.AddRegistry<BusinessRegistry>();
                p.AddRegistry<DomainRegistry>();
                p.AddRegistry<PersistenceRegistry>();
                p.AddRegistry<ServicesRegistry>();
            });
        }
    }
}
