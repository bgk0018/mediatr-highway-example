using System;
using Domain.Accounts;
using Domain.Tests.Framework.AutoMoq;
using TestingFramework.Categories;
using Xunit;

namespace Domain.Tests.Accounts
{
    public class AccountIdTests
    {
        [UnitTest]
        public class TheConstructorMethod
        {
            [Fact]
            public void Throws_ArgumentException_On_Id_Zero()
            {
                Assert.Throws<ArgumentException>(() => { new AccountId(0); });
            }

            [Fact]
            public void Throws_ArgumentException_On_Id_Less_Than_Zero()
            {
                Assert.Throws<ArgumentException>(() => { new AccountId(-1); });
            }
        }

        [UnitTest]
        public class TheEqualMethod
        {
            [AutoMoqData]
            [Theory]
            public void Returns_True(AccountId sut)
            {
                Assert.True(sut.Equals(sut));
            }

            [AutoMoqData]
            [Theory]
            public void Returns_False_On_Type(AccountId sut)
            {
                var value = sut.ToString();

                Assert.True(!sut.Equals(value));
            }

            [AutoMoqData]
            [Theory]
            public void Returns_False_On_NotEqual(
                AccountId sut,
                AccountId other)
            {
                Assert.True(!sut.Equals(other));
            }

            [AutoMoqData]
            [Theory]
            public void Returns_False_On_Null(AccountId sut)
            {
                Assert.True(!sut.Equals(null));
            }
        }

        [UnitTest]
        public class TheGetHashCodeMethod
        {
            [AutoMoqData]
            [Theory]
            public void Succeed_With_Valid_Request(AccountId sut)
            {
                var value = int.Parse(sut.ToString());

                Assert.True(value.GetHashCode() == sut.GetHashCode());
            }
        }

        [UnitTest]
        public class TheEqualityOperatorMethod
        {
            [AutoMoqData]
            [Theory]
            public void True_With_Valid_Request(AccountId sut)
            {
                var compared = new AccountId(int.Parse(sut.ToString()));

                Assert.True(sut == compared);
            }

            [AutoMoqData]
            [Theory]
            public void False_With_Valid_Request(AccountId sut)
            {
                var compared = new AccountId(int.Parse(sut.ToString())+1);

                Assert.True(!(sut == compared));
            }
        }

        [UnitTest]
        public class TheInequalityOperatorMethod
        {
            [AutoMoqData]
            [Theory]
            public void True_With_Valid_Request(AccountId sut)
            {
                var compared = new AccountId(int.Parse(sut.ToString()));

                Assert.True(!(sut != compared));
            }

            [AutoMoqData]
            [Theory]
            public void False_With_Valid_Request(AccountId sut)
            {
                var compared = new AccountId(int.Parse(sut.ToString()) + 1);

                Assert.True(sut != compared);
            }
        }
    }
}
