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
    public class CreateCreditHandlerTests
    {
        [UnitTest]
        public class TheHandleMethod
        {
            [AutoMoqData]
            [Theory]
            public async Task Succeed_With_Valid_Request(
                Account account,
                CreateCreditCommand command,
                [Frozen] Mock<IRepository> repo,
                CreateCreditHandler sut)
            {
                var originalBalance = account.Balance.Amount;

                repo.Setup(p => p.FindAsync(It.IsAny<IScalar<Account>>())).ReturnsAsync(account);

                var result = await sut.Handle(command, new CancellationToken());

                repo.Verify(p=>p.FindAsync(It.IsAny<IScalar<Account>>()), Times.Once());
                repo.Verify(p => p.UnitOfWork.CommitAsync(), Times.Once());

                Assert.True(result.Amount == originalBalance + command.Funds.Amount);
            }

            [AutoMoqData]
            [Theory]
            public async Task Throw_Bad_Request_With_Missing_Account(
                CreateCreditCommand command,
                [Frozen] Mock<IRepository> repo,
                CreateCreditHandler sut)
            {
                repo.Setup(p => p.FindAsync(It.IsAny<IScalar<Account>>())).ReturnsAsync((Account)null);

                await Assert.ThrowsAsync<BadRequestException>(async () => { await sut.Handle(command, new CancellationToken()); });
            }
        }
    }
}
