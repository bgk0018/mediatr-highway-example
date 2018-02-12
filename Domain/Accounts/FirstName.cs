using System;

namespace Domain.Accounts
{
    public class FirstName
    {
        private readonly string value;

        public FirstName(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (!IsValid(value))
            {
                throw new ArgumentException("Invalid value.", "value");
            }

            this.value = char.ToUpper(value[0]) + value.Substring(1).ToLower();
        }

        public static bool IsValid(string candidate)
        {
            return !string.IsNullOrEmpty(candidate);
        }

        public static bool TryParse(string candidate, out FirstName firstName)
        {
            firstName = null;

            if (string.IsNullOrWhiteSpace(candidate))
            {
                return false;
            }

            firstName = new FirstName(char.ToUpper(candidate[0]) + candidate.Substring(1).ToLower());

            return true;
        }

        public static implicit operator string(FirstName name)
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

            var other = (FirstName)obj;

            return Equals(value, other.value);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static bool operator ==(FirstName first, FirstName second)
        {
            return first?.value == second?.value;
        }

        public static bool operator !=(FirstName first, FirstName second)
        {
            return first?.value != second?.value;
        }
    }
}
