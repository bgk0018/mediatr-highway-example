namespace Domain.Accounts
{
    public class Balance
    {
        public Balance(Currency currency, decimal amount)
        {
            Currency = currency;
            Amount = amount;
        }

        public decimal Amount { get; private set; }

        public bool IsNegative => Amount < 0;

        public Currency Currency { get; }

        internal void Credit(Funds funds)
        {
            Amount += funds.Amount;
        }

        public void Debit(Funds funds)
        {
            Amount -= funds.Amount;
        }
    }
}