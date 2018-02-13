using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using AutoFixture.AutoMoq;

namespace Banking.Accounts.Tests.Framework.Customizations
{
    public class SuiteCustomizations : CompositeCustomization
    {
        public SuiteCustomizations()
            : base(
                new TestHostCustomization(),
                new ControllerCustomization(),
                new AutoMoqCustomization())
        {

        }
    }
}
