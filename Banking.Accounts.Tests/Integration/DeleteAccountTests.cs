using System.Threading.Tasks;
using Banking.Accounts.Tests.Framework;
using Banking.Accounts.Tests.Framework.AutoMoq;
using Business.Accounts.Commands;
using Business.Accounts.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace Banking.Accounts.Tests.Integration
{
    public class DeleteAccountTests
    {
        [Trait("Category" , "Integration")]
        public class Integration
        {
            [Fact]
            public async Task Succeed_With_Valid_Request()
            {
                var command = new CreateAccountCommand()
                {
                    FirstName = "Ben",
                    LastName = "Kennedy"
                };

                var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

                var client = server.CreateClient();

                var account = await client.PostAsJsonAsync<CreateAccountCommand, AccountModel>("api/accounts", command);

                await client.DeleteAsync($"api/accounts/{account.AccountId}");

                var result = await client.GetAsync<AccountModel>($"api/accounts/{account.AccountId}");

                Assert.True(result == null);
            }
        }
    }
}
