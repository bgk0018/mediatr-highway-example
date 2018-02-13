using AutoFixture;
using Banking.Accounts.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Accounts.Tests.Framework.Customizations
{
    public class ControllerCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            //TODO, create a specimenbuilder instead that will test for whether the type in question inherits from Controller instead of specifying explicitly here
            fixture.Register(() =>
            {
                return fixture.Build<AccountsController>()
                    .OmitAutoProperties()
                    .Create();
            });
        }
    }
}
