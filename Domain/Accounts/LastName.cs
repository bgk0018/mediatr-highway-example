using System;

namespace Domain.Accounts
{
    public class LastName
    {
        private readonly string value;

        public LastName(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (!IsValid(value))
            {
                throw new ArgumentException("Invalid value.", "value");
            }

            this.value = value;
        }

        public static bool IsValid(string candidate)
        {
            if (string.IsNullOrEmpty(candidate))
            {
                return false;
            }

            return char.ToUpper(candidate[0]) + candidate.Substring(1).ToLower() == candidate;
        }

        public static bool TryParse(string candidate, out LastName firstName)
        {
            firstName = null;

            if (string.IsNullOrWhiteSpace(candidate))
            {
                return false;
            }

            firstName = new LastName(char.ToUpper(candidate[0]) + candidate.Substring(1).ToLower());

            return true;
        }

        public static implicit operator string(LastName name)
        {
            return name.value;
        }

        public override string ToString()
        {
            return value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (LastName)obj;

            return Equals(value, other.value);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static bool operator ==(LastName first, LastName second)
        {
            return first?.value == second?.value;
        }

        public static bool operator !=(LastName first, LastName second)
        {
            return first?.value != second?.value;
        }
    }
}
