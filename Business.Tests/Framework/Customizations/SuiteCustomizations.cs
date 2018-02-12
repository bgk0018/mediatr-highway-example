using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using AutoFixture.AutoMoq;

namespace Business.Tests.Framework.Customizations
{
    public class SuiteCustomizations : CompositeCustomization
    {
        public SuiteCustomizations()
            : base(
                new FundsCustomization(),
                new FundsModelCustomization(),
                new AutoMoqCustomization())
        {
            
        }
    }
}
