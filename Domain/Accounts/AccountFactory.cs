using System;
using SimpleIdGenerator;

namespace Domain.Accounts
{
    public class AccountFactory : IAccountFactory
    {
        private readonly IdGenerator generator;

        public AccountFactory(IdGenerator generator)
        {
            this.generator = generator ?? throw new ArgumentNullException(nameof(generator));
        }

        public Account Build(AccountHolder holder)
        {
            return new Account(new AccountId(generator.Get()), holder);
        }
    }
}