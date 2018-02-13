using System;
using System.Collections.Generic;
using System.Text;
using Domain.Accounts;
using Domain.Tests.Framework.AutoMoq;
using Xunit;

namespace Domain.Tests.Accounts
{
    public class TransferFundsServiceTests
    {
        [Trait("Category", "Unit")]
        public class TheTransferMethod
        {
            [AutoMoqData]
            [Theory]
            public void Succeed_With_Valid_Request(
                Account from,
                Account to,
                Funds funds,
                TransferFundsService sut)
            {
                from.Credit(funds);

                var initialFrom = from.Balance.Amount;
                var initialTo = to.Balance.Amount;

                sut.Transfer(from, to, funds);

                Assert.True(initialTo + funds.Amount == to.Balance.Amount);
                Assert.True(initialFrom - funds.Amount == from.Balance.Amount);
            }

            [AutoMoqData]
            [Theory]
            public void Throw_ArgumentNullException_On_Null_To_Account(
                Account from,
                Funds funds,
                TransferFundsService sut)
            {
                Assert.Throws<ArgumentNullException>(() => { sut.Transfer(from, null, funds); });
            }

            [AutoMoqData]
            [Theory]
            public void Throw_ArgumentNullException_On_Null_From_Account(
                Account to,
                Funds funds,
                TransferFundsService sut)
            {
                Assert.Throws<ArgumentNullException>(() => { sut.Transfer(null, to, funds); });
            }

            [AutoMoqData]
            [Theory]
            public void Throw_ArgumentNullException_On_Null_Funds(
                Account to,
                Account from,
                TransferFundsService sut)
            {
                Assert.Throws<ArgumentNullException>(() => { sut.Transfer(from, to, null); });
            }
        }
    }
}
