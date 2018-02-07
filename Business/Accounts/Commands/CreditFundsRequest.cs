using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Business.Accounts.Commands
{
    public class CreditFundsRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
