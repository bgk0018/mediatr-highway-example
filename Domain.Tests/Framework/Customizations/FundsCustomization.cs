using System;
using AutoFixture;
using Domain.Accounts;

namespace Domain.Tests.Framework.Customizations
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
