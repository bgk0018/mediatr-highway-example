using AutoFixture;
using Domain.Accounts;
using Highway.Data;

namespace Persistence.Tests.Framework.Customizations
{
    public class RepositoryCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register(() => SeededDatabase(fixture));
        }

        private Repository SeededDatabase(IFixture fixture)
        {
            var context = new InMemoryDataContext();

            context.Add(fixture.Create<Account>());
            context.Add(fixture.Create<Account>());
            context.Add(fixture.Create<Account>());

            context.Commit();

            return new Repository(context);
        }
    }
}
