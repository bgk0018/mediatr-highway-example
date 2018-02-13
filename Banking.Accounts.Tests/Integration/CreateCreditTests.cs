using System.Threading.Tasks;
using Banking.Accounts.Tests.Framework;
using Banking.Accounts.Tests.Framework.AutoMoq;
using Business.Accounts.Commands;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using Business.Accounts.Models;

namespace Banking.Accounts.Tests.Integration
{
    public class CreateCreditTests
    {
        [Trait("Category", "Integration")]
        public class Integration
        {
            [AutoMoqData]
            [Theory]
            public async Task Succeed_With_Valid_Request(
                CreateAccountCommand createAccountCommand,
                CreateCreditCommand createCreditCommand,
                TestServer server)
            {
                var client = server.CreateClient();

                var accountModel = await client.PostAsJsonAsync<CreateAccountCommand, AccountModel>("api/accounts", createAccountCommand);

                var fundsModel = await client.PostAsJsonAsync<FundsModel, FundsModel>($"api/accounts/{accountModel.AccountId}/credits",
                    createCreditCommand.Funds);

                var result = await client.GetAsync<AccountModel>($"api/accounts/{accountModel.AccountId}");

                Assert.True(result.Balance == fundsModel.Amount);
            }

            [AutoMoqData]
            [Theory]
            public async Task Fail_With_Invalid_Amount(
                CreateAccountCommand createAccountCommand,
                CreateCreditCommand createCreditCommand,
                TestServer server)
            {
                createCreditCommand.Funds.Amount = -100m;

                var client = server.CreateClient();

                var accountModel = await client.PostAsJsonAsync<CreateAccountCommand, AccountModel>("api/accounts", createAccountCommand);

                var fundsModel = await client.PostAsJsonAsync<FundsModel, FundsModel>($"api/accounts/{accountModel.AccountId}/credits", createCreditCommand.Funds);

                Assert.True(fundsModel == null);
            }

            [AutoMoqData]
            [Theory]
            public async Task Fail_With_Invalid_Currency(
                CreateAccountCommand createAccountCommand,
                CreateCreditCommand createCreditCommand,
                TestServer server)
            {
                createCreditCommand.Funds.Currency = "Garbage";

                var client = server.CreateClient();

                var accountModel = await client.PostAsJsonAsync<CreateAccountCommand, AccountModel>("api/accounts", createAccountCommand);

                var fundsModel = await client.PostAsJsonAsync<FundsModel, FundsModel>($"api/accounts/{accountModel.AccountId}/credits", createCreditCommand.Funds);

                Assert.True(fundsModel == null);
            }
        }
    }
}
