using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Banking.Accounts.Controllers;
using Banking.Accounts.Tests.Framework.AutoMoq;
using Business.Accounts.Commands;
using Business.Accounts.Models;
using Business.Accounts.Queries;
using Business.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

using Xunit;

namespace Banking.Accounts.Tests.Controllers
{
    public class AccountsControllerTests
    {
        [Trait("Category", "Unit")]
        public class TheGetMethod
        {
            [AutoMoqData]
            [Theory]
            public async Task Returns_Ok_With_Valid_Request(
                GetAccountQuery query,
                AccountModel model,
                [Frozen] Mock<IMediator> mediator,
                AccountsController sut)
            {
                mediator.Setup(p => p.Send(It.IsAny<IRequest<AccountModel>>(), It.IsAny<CancellationToken>())).ReturnsAsync(model);

                var result = await sut.Get(query) as OkObjectResult;

                Assert.True(result != null);
                Assert.True(result.StatusCode == 200);
                Assert.True((AccountModel)result.Value == model);
            }
        }

        [Trait("Category", "Unit")]
        public class ThePostMethod
        {
            [AutoMoqData]
            [Theory]
            public async Task Returns_Created_With_Valid_Request(
                CreateAccountCommand command,
                AccountModel model,
                [Frozen] Mock<IMediator> mediator,
                AccountsController sut)
            {
                mediator.Setup(p => p.Send(It.IsAny<IRequest<AccountModel>>(), It.IsAny<CancellationToken>())).ReturnsAsync(model);

                var message = await sut.Post(command) as CreatedResult;

                var returnModel = (AccountModel) message.Value;

                Assert.True(message != null);
                Assert.True(message.StatusCode == 201);
                Assert.True(message.Location == $"api/accounts/{returnModel.AccountId}");
                Assert.True((AccountModel)message.Value == model);
            }
        }

        [Trait("Category", "Unit")]
        public class ThePostCreditMethod
        {
            [AutoMoqData]
            [Theory]
            public async Task Returns_Created_With_Valid_Request(
                CreateCreditCommand command,
                FundsModel model,
                [Frozen] Mock<IMediator> mediator,
                AccountsController sut)
            {
                mediator.Setup(p => p.Send(It.IsAny<IRequest<FundsModel>>(), It.IsAny<CancellationToken>())).ReturnsAsync(model);

                var message = await sut.PostCredit(command) as OkObjectResult;

                Assert.True(message != null);
                Assert.True(message.StatusCode == 200);
                Assert.True((FundsModel)message.Value == model);
            }
        }

        [Trait("Category", "Unit")]
        public class ThePostDebitMethod
        {
            [AutoMoqData]
            [Theory]
            public async Task Returns_Created_With_Valid_Request(
                CreateDebitCommand command,
                FundsModel model,
                [Frozen] Mock<IMediator> mediator,
                AccountsController sut)
            {
                mediator.Setup(p => p.Send(It.IsAny<IRequest<FundsModel>>(), It.IsAny<CancellationToken>())).ReturnsAsync(model);

                var message = await sut.PostDebit(command) as OkObjectResult;

                Assert.True(message != null);
                Assert.True(message.StatusCode == 200);
                Assert.True((FundsModel)message.Value == model);
            }
        }

        [Trait("Category", "Unit")]
        public class ThePostTransferMethod
        {
            [AutoMoqData]
            [Theory]
            public async Task Returns_Created_With_Valid_Request(
                CreateTransferCommand command,
                FundsModel model,
                [Frozen] Mock<IMediator> mediator,
                AccountsController sut)
            {
                mediator.Setup(p => p.Send(It.IsAny<IRequest<FundsModel>>(), It.IsAny<CancellationToken>())).ReturnsAsync(model);

                var message = await sut.PostTransfer(command) as OkObjectResult;

                Assert.True(message != null);
                Assert.True(message.StatusCode == 200);
                Assert.True((FundsModel)message.Value == model);
            }
        }
    }
}
