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
using TestingFramework.Categories;
using Xunit;

namespace Business.Tests.Accounts.Commands
{
    public class CreateTransferHandlerTests
    {
        [UnitTest]
        public class TheHandleMethod
        {
            [AutoMoqData]
            [Theory]
            public async Task Succeed_On_Valid_Request(
                CreateTransferCommand command,
                [Frozen] Mock<IRepository> repo,
                Account toAccount,
                Account fromAccount,
                CreateTransferHandler sut)
            {
                fromAccount.Credit(new Funds(Currency.USD, command.Funds.Amount));

                var initialToAccount = toAccount.Balance.Amount;
                var initialFromAccount = fromAccount.Balance.Amount;

                repo.SetupSequence(p => p.FindAsync(It.IsAny<Scalar<Account>>()))
                    .ReturnsAsync(toAccount)
                    .ReturnsAsync(fromAccount);

                var result = await sut.Handle(command, new CancellationToken());

                repo.Verify(p=>p.FindAsync(It.IsAny<Scalar<Account>>()), Times.Exactly(2));
                repo.Verify(p => p.UnitOfWork.CommitAsync(), Times.Once());

                Assert.True(result.Amount == command.Funds.Amount + initialToAccount);
                Assert.True(fromAccount.Balance.Amount == initialFromAccount - command.Funds.Amount);
            }

            [AutoMoqData]
            [Theory]
            public async Task Throws_Bad_Request_On_Missing_ToAccount(
                CreateTransferCommand command,
                [Frozen] Mock<IRepository> repo,
                Account fromAccount,
                CreateTransferHandler sut)
            {
                repo.SetupSequence(p => p.FindAsync(It.IsAny<Scalar<Account>>()))
                    .ReturnsAsync((Account)null)
                    .ReturnsAsync(fromAccount);

                await Assert.ThrowsAsync<BadRequestException>(async () => { await sut.Handle(command, new CancellationToken()); });
            }

            [AutoMoqData]
            [Theory]
            public async Task Throws_Bad_Request_On_Missing_FromAccount(
                CreateTransferCommand command,
                [Frozen] Mock<IRepository> repo,
                Account toAccount,
                CreateTransferHandler sut)
            {
                repo.SetupSequence(p => p.FindAsync(It.IsAny<Scalar<Account>>()))
                    .ReturnsAsync(toAccount)
                    .ReturnsAsync((Account)null);

                await Assert.ThrowsAsync<BadRequestException>(async () => { await sut.Handle(command, new CancellationToken()); });
            }

            [AutoMoqData]
            [Theory]
            public async Task Throws_Bad_Request_On_Insufficient_Funds(
                CreateTransferCommand command,
                [Frozen] Mock<IRepository> repo,
                Account toAccount,
                Account fromAccount,
                CreateTransferHandler sut)
            {
                fromAccount.Debit(new Funds(Currency.USD, fromAccount.Balance.Amount));

                repo.SetupSequence(p => p.FindAsync(It.IsAny<Scalar<Account>>()))
                    .ReturnsAsync(toAccount)
                    .ReturnsAsync(fromAccount);

                await Assert.ThrowsAsync<BadRequestException>(async () => { await sut.Handle(command, new CancellationToken()); });
            }
        }

        
    }
}
