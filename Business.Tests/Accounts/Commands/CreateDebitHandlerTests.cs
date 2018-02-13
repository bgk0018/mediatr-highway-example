using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Business.Accounts.Commands;
using Business.Exceptions;
using Business.Tests.Framework.AutoMoq;
using Domain.Accounts;
using Highway.Data;
using Moq;

using Xunit;

namespace Business.Tests.Accounts.Commands
{
    public class CreateDebitHandlerTests
    {
        [Trait("Category", "Unit")]
        public class TheHandleMethod
        {
            [AutoMoqData]
            [Theory]
            public async Task Succeed_With_Valid_Request(
                CreateDebitCommand command,
                Account account,
                [Frozen] Mock<IRepository> repo,
                CreateDebitHandler sut)
            {
                account.Credit(new Funds(Currency.USD, command.Funds.Amount));

                var initialBalance = account.Balance.Amount;

                repo.Setup(p => p.FindAsync(It.IsAny<IScalar<Account>>())).ReturnsAsync(account);

                var result = await sut.Handle(command, new CancellationToken());

                repo.Verify(p=>p.FindAsync(It.IsAny<IScalar<Account>>()), Times.Once());
                repo.Verify(p=>p.UnitOfWork.CommitAsync(), Times.Once());

                Assert.True(result.Amount == initialBalance - command.Funds.Amount);
            }

            [AutoMoqData]
            [Theory]
            public async Task Throw_Bad_Request_With_Insufficient_Funds(
                CreateDebitCommand command,
                Account account,
                [Frozen] Mock<IRepository> repo,
                CreateDebitHandler sut)
            {
                account.Debit(new Funds(Currency.USD, account.Balance.Amount));

                repo.Setup(p => p.FindAsync(It.IsAny<IScalar<Account>>())).ReturnsAsync(account);

                await Assert.ThrowsAsync<BadRequestException>( async () => { await sut.Handle(command, new CancellationToken()); });
            }

            [AutoMoqData]
            [Theory]
            public async Task Throw_Bad_Request_With_Missing_Account(
                CreateDebitCommand command,
                [Frozen] Mock<IRepository> repo,
                CreateDebitHandler sut)
            {
                repo.Setup(p => p.FindAsync(It.IsAny<IScalar<Account>>())).ReturnsAsync((Account) null);

                await Assert.ThrowsAsync<BadRequestException>(async () => { await sut.Handle(command, new CancellationToken()); });
            }
        }
    }
}
