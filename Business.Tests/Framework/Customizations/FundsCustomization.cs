using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Domain.Accounts;

namespace Business.Tests.Framework.Customizations
{
    public class FundsCustomization : ICustomization
    {
        private readonly Random rand;

        public FundsCustomization()
        {
            rand = new Random();
        }

        public void Customize(IFixture fixture)
        {
            fixture.Register(() => new Funds(Currency.USD, (decimal)(rand.Next(1, 100000000) / 1.37)));
        }

    }
}
