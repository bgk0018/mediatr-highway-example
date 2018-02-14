using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Business.Accounts.Commands;
using Domain.Accounts;
using Highway.Data;
using Moq;
using Xunit;

namespace Business.Tests.Accounts.Commands
{
    public class DeleteAccountHandlerTests
    {
        public class TheHandleMethod
        {
            [Fact]
            public async Task Succeed_With_Valid_Request()
            {
                var command = new DeleteAccountCommand()
                {
                    Id = 1
                };

                var unitOfWork = new Mock<IWriteOnlyUnitOfWork>();
                var repo = new Mock<IRepository>();

                repo.Setup(p => p.UnitOfWork).Returns(unitOfWork.Object);

                var account = new Account(
                    new AccountId(1),
                    new AccountHolder(
                        new FirstName("Ben"),
                        new LastName("Kennedy")));

                repo.Setup(p => p.FindAsync(It.IsAny<IScalar<Account>>())).ReturnsAsync(account);

                var sut = new DeleteAccountHandler(repo.Object);

                await sut.Handle(command, new CancellationToken());

                repo.Verify(p=>p.FindAsync(It.IsAny<IScalar<Account>>()), Times.Once());
                unitOfWork.Verify(p => p.Remove(It.IsAny<Account>()), Times.Once());
                unitOfWork.Verify(p=>p.CommitAsync(), Times.Once());
            }
        }
    }
}
