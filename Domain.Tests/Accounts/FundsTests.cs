using System;
using System.Collections.Generic;
using System.Text;
using Domain.Accounts;
using Domain.Tests.Framework.AutoMoq;

using Xunit;

namespace Domain.Tests.Accounts
{
    public class FundsTests
    {
        [Trait("Category", "Unit")]
        public class TheConstructorMethod
        {
            [Theory]
            [AutoMoqData]
            public void Succeed_With_Enum_Currency(decimal amount)
            {
                new Funds(Currency.USD, amount);
            }

            [Theory]
            [AutoMoqData]
            public void Succeed_With_String_Currency(decimal amount)
            {
                new Funds("USD", amount);
            }

            [Theory]
            [AutoMoqData]
            public void Throws_ArgumentOutOfRangeException_On_Bad_Parse(
                decimal amount,
                string notValidCurrency)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => { new Funds(notValidCurrency, amount); });
            }

            [Theory]
            [AutoMoqData]
            public void Throws_ArgumentOutOfRangeException_On_Negative_Amount(decimal amount)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => { new Funds(Currency.USD, -1*amount); });
            }
        }
    }
}
