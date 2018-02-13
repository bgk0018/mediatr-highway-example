using System;
using Domain.Accounts;
using Domain.Tests.Framework.AutoMoq;
using Xunit;


namespace Domain.Tests.Accounts
{
    public class AccountFactoryTests
    {
        [Trait("Category", "Unit")]
        public class TheBuildMethod
        {
            [AutoMoqData]
            [Theory]
            public void Succeed_With_Valid_Request(
                AccountHolder holder,
                AccountFactory sut)
            {
                var result = sut.Build(holder);

                Assert.True(result.Balance.Amount == 0);
                Assert.True(result.Holder.FirstName == holder.FirstName);
            }
        }

        [Trait("Category", "Unit")]
        public class TheConstructorMethod
        {
            [Fact]
            public void Throws_With_ArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => { new AccountFactory(null); });
            }
        }
    }
}
