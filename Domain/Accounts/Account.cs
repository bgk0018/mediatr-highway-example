using System;

namespace Domain.Accounts
{
    public class Account
    {
        private Balance balance;
        private AccountHolder holder;

        public Account(AccountId id, AccountHolder holder)
        {
            Id = id;
            Holder = holder;
            Balance = Balance.CreateEmpty();
        }

        public Account(AccountId id, AccountHolder holder, Balance balance)
        {
            Id = id;
            Holder = holder;
            Balance = balance;
        }

        public AccountHolder Holder
        {
            get => holder;
            private set => holder = value ?? throw new ArgumentNullException(nameof(value), "Cannot be null");
        }

        public Balance Balance
        {
            get => balance;
            private set => balance = value ?? throw new ArgumentNullException(nameof(value), "Cannot be null");
        }

        public AccountId Id { get; }

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