using System;
using System.Collections.Generic;
using System.Text;
using Domain.Accounts;
using Domain.Tests.Framework.AutoMoq;

using Xunit;

namespace Domain.Tests.Accounts
{
    public class AccountTests
    {
        [Trait("Category", "Unit")]
        public class TheConstructorMethod
        {
            [AutoMoqData]
            [Theory]
            public void Throw_ArgumentNullException_On_Null_AccountHolder(AccountId id)
            {
                Assert.Throws<ArgumentNullException>(() => { new Account(id, null); });
            }

            [AutoMoqData]
            [Theory]
            public void Throw_ArgumentNullException_On_Null_Balance(
                AccountId id,
                AccountHolder holder)
            {
                Assert.Throws<ArgumentNullException>(() => { new Account(id, holder, null); });
            }

            [AutoMoqData]
            [Theory]
            public void Succeed_With_No_Balance_Provided(
                AccountId id,
                AccountHolder holder)
            {
                var result = new Account(id, holder);

                Assert.True(result.Balance.Amount == 0);
                Assert.True(result.Balance.Currency == Currency.USD);
            }

            [AutoMoqData]
            [Theory]
            public void Succeed_With_Balance_Provided(
                AccountId id,
                Balance balance,
                AccountHolder holder)
            {
                var result = new Account(id, holder, balance);

                Assert.True(result.Balance.Amount == balance.Amount);
            }
        }

        [Trait("Category", "Unit")]
        public class TheDebitMethod
        {
            [AutoMoqData]
            [Theory]
            public void Succeed_With_Valid_Request(Account sut)
            {
                sut.Debit(new Funds(sut.Balance.Currency, sut.Balance.Amount));

                Assert.True(sut.Balance.Amount == 0);
            }
        }

        [Trait("Category", "Unit")]
        public class TheCreditMethod
        {
            [AutoMoqData]
            [Theory]
            public void Succeed_With_Valid_Request(Account sut)
            {
                var originalBalance = sut.Balance.Amount;

                sut.Credit(new Funds(sut.Balance.Currency, originalBalance));

                Assert.True(sut.Balance.Amount == originalBalance * 2);
            }
        }
    }
}
