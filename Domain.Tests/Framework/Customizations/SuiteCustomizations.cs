using AutoFixture;
using AutoFixture.AutoMoq;

namespace Domain.Tests.Framework.Customizations
{
    public class SuiteCustomizations : CompositeCustomization
    {
        public SuiteCustomizations()
            : base(
                new FundsCustomization(),
                new AutoMoqCustomization())
        {
            
        }
    }
}
