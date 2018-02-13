using System;
using Domain.Accounts;
using Domain.Tests.Framework.AutoMoq;

using Xunit;

namespace Domain.Tests.Accounts
{
    public class LastNameTests
    {
        [Trait("Category", "Unit")]
        public class TheConstructorMethod
        {
            [Fact]
            public void Throw_ArgumentNullException_On_Null()
            {
                Assert.Throws<ArgumentNullException>(() => { new LastName(null); });
            }

            [Fact]
            public void Throw_ArgumentException_On_Empty()
            {
                Assert.Throws<ArgumentException>(() => { new LastName(string.Empty); });
            }
        }

        [Trait("Category", "Unit")]
        public class TheTryParseMethod
        {
            [Fact]
            public void Succeed_With_Valid_Request()
            {
                var result = LastName.TryParse("SomeName", out LastName lastName);

                Assert.True(result);
                Assert.True(lastName.ToString() == "Somename");
            }

            [Fact]
            public void Fail_With_Null()
            {
                var result = LastName.TryParse(null, out LastName lastName);

                Assert.True(!result);
            }

            [Fact]
            public void Fail_With_EmptyString()
            {
                var result = LastName.TryParse(string.Empty, out LastName lastName);

                Assert.True(!result);
            }
        }

        [Trait("Category", "Unit")]
        public class TheEqualsMethod
        {
            [AutoMoqData]
            [Theory]
            public void True_With_Valid_Request(LastName sut)
            {
                Assert.True(sut.Equals(sut));
            }

            [AutoMoqData]
            [Theory]
            public void False_With_Null_Object(LastName sut)
            {
                Assert.True(!sut.Equals(null));
            }

            [AutoMoqData]
            [Theory]
            public void False_With_Different_Object(
                int notLastName,
                LastName sut)
            {
                Assert.True(!sut.Equals(notLastName));
            }
        }

        [Trait("Category", "Unit")]
        public class TheEqualityOperatorMethod
        {
            [AutoMoqData]
            [Theory]
            public void True_With_Valid_Request(LastName sut)
            {
                var compared = new LastName(sut.ToString());

                Assert.True(sut == compared);
            }

            [AutoMoqData]
            [Theory]
            public void False_With_Valid_Request(LastName sut)
            {
                var compared = new LastName(sut + "y");

                Assert.True(!(sut == compared));
            }
        }

        [Trait("Category", "Unit")]
        public class TheInequalityOperatorMethod
        {
            [AutoMoqData]
            [Theory]
            public void True_With_Valid_Request(LastName sut)
            {
                var compared = new LastName(sut.ToString());

                Assert.True(!(sut != compared));
            }

            [AutoMoqData]
            [Theory]
            public void False_With_Valid_Request(LastName sut)
            {
                var compared = new LastName(sut + "y");

                Assert.True(sut != compared);
            }
        }

        [Trait("Category", "Unit")]
        public class TheHashCodeMethod
        {
            [AutoMoqData]
            [Theory]
            public void Succeed_With_Valid_Request(LastName sut)
            {
                var expected = sut.ToString().GetHashCode();

                var result = sut.GetHashCode();

                Assert.True(expected == result);
            }
        }
    }
}
