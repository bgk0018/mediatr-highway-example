using System;

namespace Domain.Accounts
{
    public struct AccountId
    {
        private readonly int value;

        public AccountId(int value)
        {
            if (!IsValid(value))
            {
                throw new ArgumentException("Invalid value.", "value");
            }

            this.value = value;
        }

        public static bool IsValid(int candidate)
        {
            return candidate > 0;
        }

        public static implicit operator int(AccountId id)
        {
            return id.value;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (AccountId)obj;

            return Equals(value, other.value);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static bool operator ==(AccountId first, AccountId second)
        {
            return first.value == second.value;
        }

        public static bool operator !=(AccountId first, AccountId second)
        {
            return first.value != second.value;
        }
    }
}