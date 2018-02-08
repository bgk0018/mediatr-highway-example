using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Accounts.Models
{
    public class AccountModel
    {
        public decimal Balance { get; set; }

        public string Currency { get; set; }

        public int AccountId { get; set; }
    }
}
