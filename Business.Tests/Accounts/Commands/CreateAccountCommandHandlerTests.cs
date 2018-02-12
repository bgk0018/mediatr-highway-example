using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Business.Accounts.Commands;
using Business.Accounts.Models;
using Business.Tests.Framework.AutoMoq;
using Domain.Accounts;
using Highway.Data;
using Mapping;
using Moq;
using TestingFramework.Categories;
using Xunit;

namespace Business.Tests.Accounts.Commands
{
    public class CreateAccountCommandHandlerTests
    {
        [UnitTest]
        public class TheHandleMethod
        {
            [AutoMoqData]
            [Theory]
            public async Task Succeed_With_Valid_Input(
                CreateAccountCommand command,
                Account account,
                AccountModel model,
                [Frozen] Mock<IAccountFactory> factory,
                [Frozen] Mock<IWriteOnlyUnitOfWork> unitOfWork,
                [Frozen] Mock<IMapper<Account, AccountModel>> mapper,
                CreateAccountHandler sut)
            {
                factory.Setup(p => p.Build(It.IsAny<AccountHolder>())).Returns(account);

                mapper.Setup(p => p.Map(account)).Returns(model);

                unitOfWork.Setup(p => p.Add(It.IsAny<Account>())).Returns(account);
                unitOfWork.Setup(p => p.CommitAsync()).ReturnsAsync(1);

                var result = await sut.Handle(command, new CancellationToken());

                factory.Verify(p=>p.Build(It.IsAny<AccountHolder>()), Times.Once);
                mapper.Verify(p=>p.Map(account), Times.Once());
                unitOfWork.Verify(p=>p.CommitAsync(), Times.Once());
                unitOfWork.Verify(p=>p.Add(account), Times.Once());

                Assert.True(result == model);
            }
        }
    }
}
