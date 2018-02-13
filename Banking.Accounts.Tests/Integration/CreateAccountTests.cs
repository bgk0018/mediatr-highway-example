using System.Threading.Tasks;
using Banking.Accounts.Tests.Framework.AutoMoq;
using Business.Accounts.Commands;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using Banking.Accounts.Tests.Framework;
using Business.Accounts.Models;

namespace Banking.Accounts.Tests.Integration
{
    public class CreateAccountTests
    {
        public class Integration
        { 
            [AutoMoqData]
            [Theory]
            [Trait("Category", "Integration")]
            public async Task Succeed_With_Valid_Request(
                CreateAccountCommand command,
                TestServer server)
            {
                var client = server.CreateClient();

                var result = await client.PostAsJsonAsync<CreateAccountCommand, AccountModel>("api/accounts", command);

                Assert.True(result != null);

                var accountModel = await client.GetAsync<AccountModel>("api/accounts/" + result.AccountId);

                Assert.True(accountModel != null);
                Assert.True(result.FirstName == accountModel.FirstName);
            }

            [AutoMoqData]
            [Theory]
            [Trait("Category", "Integration")]
            public async Task Fails_With_Missing_FirstName(TestServer server)
            {
                var client = server.CreateClient();

                var result = await client.PostAsJsonAsync<CreateAccountCommand, AccountModel>("api/accounts", new CreateAccountCommand()
                {
                    FirstName = string.Empty,
                    LastName = "Kennedy"
                });

                Assert.True(result == null);
            }

            [AutoMoqData]
            [Theory]
            [Trait("Category", "Integration")]
            public async Task Fails_With_Missing_LastName(TestServer server)
            {
                var client = server.CreateClient();

                var result = await client.PostAsJsonAsync<CreateAccountCommand, AccountModel>("api/accounts", new CreateAccountCommand()
                {
                    FirstName = "Ben",
                    LastName = string.Empty
                });

                Assert.True(result == null);
            }
        }
    }
    
}
