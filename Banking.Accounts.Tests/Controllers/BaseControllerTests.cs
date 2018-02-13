using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Banking.Accounts.Controllers;
using Banking.Accounts.Tests.Framework.AutoMoq;
using Business.Accounts.Models;
using Business.Accounts.Queries;
using Business.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Banking.Accounts.Tests.Controllers
{
    public class BaseControllerTests
    {
        [Trait("Category", "Unit")]
        public class TheHandleMethods
        {
            [AutoMoqData]
            [Theory]
            public async Task Returns_BadRequest_On_BadRequestException(
                GetAccountQuery query,
                [Frozen] Mock<IMediator> mediator,
                AccountsController sut)
            {
                mediator.Setup(p => p.Send(It.IsAny<IRequest<AccountModel>>(), It.IsAny<CancellationToken>())).ThrowsAsync(new BadRequestException("Uh-oh"));

                var result = await sut.Get(query) as BadRequestObjectResult;

                Assert.True(result != null);
                Assert.True(result.StatusCode == 400);
            }

            [AutoMoqData]
            [Theory]
            public async Task Returns_InternalServerError_On_Exception(
                GetAccountQuery query,
                [Frozen] Mock<IMediator> mediator,
                AccountsController sut)
            {
                mediator.Setup(p => p.Send(It.IsAny<IRequest<AccountModel>>(), It.IsAny<CancellationToken>())).ThrowsAsync(new ApplicationException("Whoops"));

                var result = await sut.Get(query) as ObjectResult;

                Assert.True(result != null);
                Assert.True(result.StatusCode == 500);
            }

            [AutoMoqData]
            [Theory]
            public async Task Returns_Forbidden_On_AuthorizationException(
                GetAccountQuery query,
                [Frozen] Mock<IMediator> mediator,
                AccountsController sut)
            {
                mediator.Setup(p => p.Send(It.IsAny<IRequest<AccountModel>>(), It.IsAny<CancellationToken>())).ThrowsAsync(new AuthorizationException("Whoops"));

                var result = await sut.Get(query) as ForbidResult;

                Assert.True(result != null);
            }

            [AutoMoqData]
            [Theory]
            public async Task Returns_BadRequest_On_Invalid_ModelState(
                GetAccountQuery query,
                AccountsController sut)
            {
                sut.ModelState.AddModelError("YoBadRequest", "Something's funky, bail!");

                var result = await sut.Get(query) as BadRequestObjectResult;

                Assert.True(result != null);
                Assert.True(result.StatusCode == 400);
            }
        }
    }
}
