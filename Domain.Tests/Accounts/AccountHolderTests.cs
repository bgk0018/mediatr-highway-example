using System;
using System.Collections.Generic;
using System.Text;
using Domain.Accounts;
using Domain.Tests.Framework.AutoMoq;
using TestingFramework.Categories;
using Xunit;

namespace Domain.Tests.Accounts
{
    public class AccountHolderTests
    {
        [UnitTest]
        public class TheConstructorMethod
        {
            [AutoMoqData]
            [Theory]
            public void Throws_ArgumentNullException_On_Null_FirstName(LastName lastName)
            {
                Assert.Throws<ArgumentNullException>(() => { new AccountHolder(null, lastName); });
            }

            [AutoMoqData]
            [Theory]
            public void Throws_ArgumentNullException_On_Null_LastName(FirstName firstName)
            {
                Assert.Throws<ArgumentNullException>(() => { new AccountHolder(firstName, null); });
            }
        }
    }
}
