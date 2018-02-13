using System;

namespace Domain.Accounts
{
    public class AccountHolder
    {
        public AccountHolder(FirstName firstName, LastName lastName)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }

        public FirstName FirstName { get; }

        public LastName LastName { get; }
    }
}