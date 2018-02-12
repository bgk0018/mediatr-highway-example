using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using Business.Accounts.Models;

namespace Business.Tests.Framework.Customizations
{
    public class FundsModelCustomization : ICustomization
    {
        private Random rand;

        public FundsModelCustomization()
        {
            this.rand = new Random();
        }

        public void Customize(IFixture fixture)
        {
            fixture.Register(() => fixture.Build<FundsModel>()
                .With(p=>p.Currency, "USD")
                .With(p=>p.Amount, (decimal)(rand.Next(1, 100000000) / 1.37))
                .Create());
        }
    }
}
