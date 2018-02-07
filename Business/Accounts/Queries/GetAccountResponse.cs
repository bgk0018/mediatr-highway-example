using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeApplication.Models;

namespace Business.Accounts.Queries
{
    public class GetAccountResponse
    {
        public decimal Balance { get; set; }

        public string Currency { get; set; }

        public Guid AccountId { get; set; }
    }
}
