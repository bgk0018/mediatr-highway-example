using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using AutoFixture.AutoMoq;
using Persistence.Tests.Framework.Customizations;

namespace Business.Tests.Framework.Customizations
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
