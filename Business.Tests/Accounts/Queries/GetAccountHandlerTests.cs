using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Business.Accounts.Models;
using Business.Accounts.Queries;
using Business.Exceptions;
using Business.Tests.Framework.AutoMoq;
using Domain.Accounts;
using Highway.Data;
using Moq;
using TestingFramework.Categories;
using Xunit;

namespace Business.Tests.Accounts.Queries
{
    public class GetAccountHandlerTests
    {
        [UnitTest]
        public class TheHandleMethod
        {
            [AutoMoqData]
            [Theory]
            public async Task Succeed_With_Valid_Request(
                GetAccountQuery query,
                Account account,
                AccountModel model,
                [Frozen] Mock<IReadOnlyRepository> repo,
                GetAccountHandler sut)
            {
                model.AccountId = account.Id;

                repo.Setup(p => p.FindAsync(It.IsAny<IScalar<Account>>())).ReturnsAsync(account);

                var result = await sut.Handle(query, new CancellationToken());

                repo.Verify(p=>p.FindAsync(It.IsAny<IScalar<Account>>()), Times.Once());

                Assert.True(result.AccountId == account.Id);
            }

            [AutoMoqData]
            [Theory]
            public async Task Throws_Bad_Request_With_Missing_Account(
                GetAccountQuery query,
                [Frozen] Mock<IRepository> repo,
                GetAccountHandler sut)
            {
                repo.Setup(p => p.FindAsync(It.IsAny<IScalar<Account>>())).ReturnsAsync((Account) null);

                await Assert.ThrowsAsync<BadRequestException>(async () => { await sut.Handle(query, new CancellationToken()); });
            }
        }
    }
}
