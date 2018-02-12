using System;

namespace Domain.Accounts
{
    public class Funds
    {
        private decimal amount;

        public Funds(string currency, decimal amount)
        {
            if (!Enum.TryParse(currency, out Currency result))
            {
                throw new ArgumentOutOfRangeException(nameof(currency), "Currency was not a valid value");
            }

            Currency = result;
            Amount = amount;
        }

        public Funds(Currency currency, decimal amount)
        {
            Currency = currency;
            Amount = amount;
        }

        public decimal Amount
        {
            get => amount;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Amount cannot be less than 0");
                }

                amount = value;
            }
        }

        public Currency Currency { get; set; }
    }
}