
using AutoFixture;
using AutoFixture.AutoMoq;
using Business.Accounts.Models;

namespace Banking.Accounts.Tests.Framework.Customizations
{
    public class SuiteCustomizations : CompositeCustomization
    {
        public SuiteCustomizations()
            : base(
                new FundsModelCustomization(),
                new TestHostCustomization(),
                new ControllerCustomization(),
                new AutoMoqCustomization())
        {

        }
    }
}
