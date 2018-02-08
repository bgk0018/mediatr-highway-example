using System;

namespace Domain.Accounts
{
    public class TransferFundsService
    {
        public void Transfer(Account from, Account to, Funds amount)
        {
            if (from == null) throw new ArgumentNullException(nameof(from));

            if (to == null) throw new ArgumentNullException(nameof(to));

            from.Debit(amount);
            to.Credit(amount);
        }
    }
}