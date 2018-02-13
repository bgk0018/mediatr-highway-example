using System.Threading.Tasks;
using Banking.Accounts.Tests.Framework;
using Banking.Accounts.Tests.Framework.AutoMoq;
using Business.Accounts.Commands;
using Business.Accounts.Models;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace Banking.Accounts.Tests.Integration
{
    public class CreateTransferTests
    {
        [Trait("Category", "Integration")]
        public class Integration
        {
            [AutoMoqData]
            [Theory]
            public async Task Succeed_With_Valid_Request(
                CreateAccountCommand createToAccountCommand,
                CreateAccountCommand createFromAccountCommand,
                CreateCreditCommand createCreditCommand,
                TestServer server)
            {
                var client = server.CreateClient();

                var initialToAccount = await client.PostAsJsonAsync<CreateAccountCommand, AccountModel>("api/accounts", createToAccountCommand);

                var initialFromAccount = await client.PostAsJsonAsync<CreateAccountCommand, AccountModel>("api/accounts", createFromAccountCommand);

                var funds = await client.PostAsJsonAsync<FundsModel, FundsModel>($"api/accounts/{initialFromAccount.AccountId}/credits", createCreditCommand.Funds);

                var createTransferCommand = new CreateTransferCommand()
                {
                    Funds = createCreditCommand.Funds,
                    ReceivingAccountId = initialToAccount.AccountId,
                    SendingAccountId = initialFromAccount.AccountId
                };

                await client.PostAsJsonAsync<CreateTransferCommand, FundsModel>($"api/accounts/transfers", createTransferCommand);

                var resultToAccount = await client.GetAsync<AccountModel>($"api/accounts/{initialToAccount.AccountId}");
                var resultFromAccount = await client.GetAsync<AccountModel>($"api/accounts/{initialFromAccount.AccountId}");

                Assert.True(initialFromAccount.Balance ==
                            resultFromAccount.Balance - createCreditCommand.Funds.Amount);

                Assert.True(initialToAccount.Balance ==
                            resultToAccount.Balance + createCreditCommand.Funds.Amount);
            }
        }
    }
}
