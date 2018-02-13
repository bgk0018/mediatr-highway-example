using System.Threading.Tasks;
using Banking.Accounts.Tests.Framework;
using Banking.Accounts.Tests.Framework.AutoMoq;
using Business.Accounts.Commands;
using Business.Accounts.Models;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace Banking.Accounts.Tests.Integration
{
    public class CreateDebitTests
    {
        [Trait("Category", "Integration")]
        public class Integration
        {
            [AutoMoqData]
            [Theory]
            public async Task Succeed_With_Valid_Request(
                CreateAccountCommand createAccountCommand,
                CreateDebitCommand createDebitCommand,
                TestServer server)
            {
                var client = server.CreateClient();

                var accountModel = await client.PostAsJsonAsync<CreateAccountCommand, AccountModel>("api/accounts", createAccountCommand);



                var fundsModel = await client.PostAsJsonAsync<FundsModel, FundsModel>($"api/accounts/{accountModel.AccountId}/debits", createDebitCommand.Funds);

                var result = await client.GetAsync<AccountModel>($"api/accounts/{accountModel.AccountId}");

                Assert.True(result.Balance == fundsModel.Amount);
            }

            [AutoMoqData]
            [Theory]
            public async Task Fail_With_Invalid_Amount(
                CreateAccountCommand createAccountCommand,
                CreateDebitCommand createDebitCommand,
                TestServer server)
            {
                createDebitCommand.Funds.Amount = -100m;

                var client = server.CreateClient();

                var accountModel = await client.PostAsJsonAsync<CreateAccountCommand, AccountModel>("api/accounts", createAccountCommand);

                var fundsModel = await client.PostAsJsonAsync<FundsModel, FundsModel>($"api/accounts/{accountModel.AccountId}/debits", createDebitCommand.Funds);

                Assert.True(fundsModel == null);
            }

            [AutoMoqData]
            [Theory]
            public async Task Fail_With_Invalid_Currency(
                CreateAccountCommand createAccountCommand,
                CreateDebitCommand createDebitCommand,
                TestServer server)
            {
                createDebitCommand.Funds.Currency = "Garbage";

                var client = server.CreateClient();

                var accountModel = await client.PostAsJsonAsync<CreateAccountCommand, AccountModel>("api/accounts", createAccountCommand);

                var fundsModel = await client.PostAsJsonAsync<FundsModel, FundsModel>($"api/accounts/{accountModel.AccountId}/debits", createDebitCommand.Funds);

                Assert.True(fundsModel == null);
            }
        }
    }
}
