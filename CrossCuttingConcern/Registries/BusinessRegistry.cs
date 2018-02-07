using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Business.Accounts.Commands;
using MediatR;
using StructureMap;

namespace CrossCuttingConcern.Registries
{
    internal class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<CreditFundsHandler>();
                scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
            });
            For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => ctx.GetInstance);
            For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => ctx.GetAllInstances);
            For<IMediator>().Use<Mediator>();
        }
    }
}
