using System;

namespace Domain.Accounts
{
    public class AccountId
    {
        private Guid value;

        public AccountId(Guid value)
        {
            Value = value;
        }

        public Guid Value
        {
            get => value;
            private set
            {
                if (value == Guid.Empty)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Cannot be an empty guid");
                }

                this.value = value;
            }
        }
    }
}
