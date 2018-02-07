using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using CrossCuttingConcern.Registries;
using StructureMap;
using WebApi.StructureMap;

namespace SomeApplication
{
    public static class ContainerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new Container();

            container.Compose();
            container.AssertConfigurationIsValid();

            config.UseStructureMap(container);
        }
    }
}