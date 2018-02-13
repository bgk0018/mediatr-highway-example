using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Accounts;
using Highway.Data;
using Microsoft.VisualStudio.TestPlatform.TestExecutor;
using Persistence.Accounts.Queries;
using Persistence.Tests.Framework.AutoMoq;
using TestingFramework.Categories;
using Xunit;

namespace Persistence.Tests.Accounts.Queries
{
    public class GetByIdTests
    {
        [UnitTest]
        public class TheConstructorMethod
        {
            [AutoMoqData]
            [Theory]
            public async Task Succeed_With_Valid_Request(
                Account account,
                Repository repo)
            {
                repo.UnitOfWork.Add(account);
                await repo.UnitOfWork.CommitAsync();

                var sut = new GetById(account.Id);

                var result = await repo.FindAsync(sut);

                Assert.NotNull(result);
                Assert.True(account.Id == result.Id);
            }
        }
    }
}
