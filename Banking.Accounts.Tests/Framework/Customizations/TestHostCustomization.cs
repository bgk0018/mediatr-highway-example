using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace Banking.Accounts.Tests.Framework.Customizations
{
    public class TestHostCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register(() => new TestServer(new WebHostBuilder().UseStartup<Startup>()));
        }
    }
}
