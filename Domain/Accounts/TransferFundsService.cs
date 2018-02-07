using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Accounts
{
    public class TransferFundsService
    {
        public void Transfer(Account from, Account to, Funds amount)
        {
            if (from == null)
            {
                throw new ArgumentNullException(nameof(from));
            }

            if (to == null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            from.Debit(amount);
            to.Credit(amount);
        }
    }
}
