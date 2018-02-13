using System;
using System.Collections.Generic;
using System.Text;
using Business.Tests.Framework.AutoMoq;
using Domain.Accounts;
using TestingFramework.Categories;
using Xunit;

namespace Domain.Tests.Accounts
{
    public class AccountIdTests
    {
        [UnitTest]
        public class TheConstructorMethod
        {
            [AutoMoqData]
            [Theory]
            public void Throws_ArgumentException_On_Id_Zero()
            {
                Assert.Throws<ArgumentException>(() => { new AccountId(0); });
            }

            [AutoMoqData]
            [Theory]
            public void Throws_ArgumentException_On_Id_Less_Than_Zero()
            {
                Assert.Throws<ArgumentException>(() => { new AccountId(-1); });
            }
        }
    }
}
