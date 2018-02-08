using System;

namespace Domain.Accounts
{
    public class Account
    {
        private Balance balance;
        private AccountId id;

        public Account(AccountId id, Balance balance)
        {
            Id = id;
            Balance = balance;
        }

        public Balance Balance
        {
            get => balance;
            private set => balance = value ?? throw new ArgumentNullException(nameof(value), "Cannot be null");
        }

        public AccountId Id
        {
            get => id;
            private set => id = value ?? throw new ArgumentNullException(nameof(value), "Cannot be null");
        }

        public void Credit(Funds funds)
        {
            Balance.Credit(funds);
        }

        public void Debit(Funds funds)
        {
            Balance.Debit(funds);
        }
    }
}