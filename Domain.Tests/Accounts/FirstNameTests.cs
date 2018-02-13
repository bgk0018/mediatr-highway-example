using System;
using System.Collections.Generic;
using System.Text;
using Domain.Accounts;
using Domain.Tests.Framework.AutoMoq;
using TestingFramework.Categories;
using Xunit;

namespace Domain.Tests.Accounts
{
    public class FirstNameTests
    {
        [UnitTest]
        public class TheConstructorMethod
        {
            [Fact]
            public void Throw_ArgumentNullException_On_Null()
            {
                Assert.Throws<ArgumentNullException>(() => { new FirstName(null); });
            }

            [Fact]
            public void Throw_ArgumentException_On_Empty()
            {
                Assert.Throws<ArgumentException>(() => { new FirstName(string.Empty); });
            }
        }

        [UnitTest]
        public class TheTryParseMethod
        {
            [Fact]
            public void Succeed_With_Valid_Request()
            {
                var result = FirstName.TryParse("SomeName", out FirstName firstName);

                Assert.True(result);
                Assert.True(firstName.ToString() == "Somename");
            }

            [Fact]
            public void Fail_With_Null()
            {
                var result = FirstName.TryParse(null, out FirstName firstName);

                Assert.True(!result);
            }

            [Fact]
            public void Fail_With_EmptyString()
            {
                var result = FirstName.TryParse(string.Empty, out FirstName firstName);

                Assert.True(!result);
            }
        }

        [UnitTest]
        public class TheEqualsMethod
        {
            [AutoMoqData]
            [Theory]
            public void True_With_Valid_Request(FirstName sut)
            {
                Assert.True(sut.Equals(sut));
            }

            [AutoMoqData]
            [Theory]
            public void False_With_Null_Object(FirstName sut)
            {
                Assert.True(!sut.Equals(null));
            }

            [AutoMoqData]
            [Theory]
            public void False_With_Different_Object(
                int notFirstName,
                FirstName sut)
            {
                Assert.True(!sut.Equals(notFirstName));
            }
        }

        [UnitTest]
        public class TheEqualityOperatorMethod
        {
            [AutoMoqData]
            [Theory]
            public void True_With_Valid_Request(FirstName sut)
            {
                var compared = new FirstName(sut.ToString());

                Assert.True(sut == compared);
            }

            [AutoMoqData]
            [Theory]
            public void False_With_Valid_Request(FirstName sut)
            {
                var compared = new FirstName(sut+"y");

                Assert.True(!(sut == compared));
            }
        }

        [UnitTest]
        public class TheInequalityOperatorMethod
        {
            [AutoMoqData]
            [Theory]
            public void True_With_Valid_Request(FirstName sut)
            {
                var compared = new FirstName(sut.ToString());

                Assert.True(!(sut != compared));
            }

            [AutoMoqData]
            [Theory]
            public void False_With_Valid_Request(FirstName sut)
            {
                var compared = new FirstName(sut+"y");

                Assert.True(sut != compared);
            }
        }

        [UnitTest]
        public class TheHashCodeMethod
        {
            [AutoMoqData]
            [Theory]
            public void Succeed_With_Valid_Request(FirstName sut)
            {
                var expected = sut.ToString().GetHashCode();

                var result = sut.GetHashCode();

                Assert.True(expected == result);
            }
        }
    }
}
