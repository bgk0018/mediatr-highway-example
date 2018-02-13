using AutoFixture;
using AutoFixture.AutoMoq;

namespace Persistence.Tests.Framework.Customizations
{
    public class SuiteCustomizations : CompositeCustomization
    {
        public SuiteCustomizations()
            : base(
                new RepositoryCustomization(),
                new AutoMoqCustomization())
        {
            
        }
    }
}
