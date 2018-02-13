using AutoFixture;
using AutoFixture.Xunit2;
using Banking.Accounts.Tests.Framework.Customizations;

namespace Banking.Accounts.Tests.Framework.AutoMoq
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(() =>
            {
                var fixture = new Fixture().Customize(new SuiteCustomizations());

                return fixture;
            })
        {
        }
    }
}