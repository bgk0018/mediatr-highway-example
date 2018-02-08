using System;

namespace Domain.Accounts
{
    public class AccountId
    {
        private int value;

        public AccountId(int value)
        {
            Value = value;
        }

        public int Value
        {
            get => value;
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Cannot be an empty guid");

                this.value = value;
            }
        }
    }
}