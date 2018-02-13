using System.Net.Http;
using System.Threading.Tasks;
using Banking.Accounts.Tests.Framework.AutoMoq;
using Business.Accounts.Commands;
using Microsoft.AspNetCore.TestHost;
using TestingFramework.Categories;
using Xunit;
using Banking.Accounts.Tests.Framework;
using Business.Accounts.Models;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Accounts.Tests.Integration
{
    public class Integration
    {
        public class CreateAccountTests
        {
            [AutoMoqData]
            [Theory]
            [IntegrationTest]
            public async Task Succeed_With_Valid_Request(TestServer server)
            {
                var client = server.CreateClient();

                var result = await client.PostAsJsonAsync<CreateAccountCommand, AccountModel>("api/accounts", new CreateAccountCommand()
                {
                    FirstName = "Ben",
                    LastName = "Kennedy"
                });

                var accountModel = await client.GetAsync<AccountModel>("api/accounts/" + result.AccountId);

                Assert.True(result.FirstName == accountModel.FirstName);
            }
        }
    }
    
}
