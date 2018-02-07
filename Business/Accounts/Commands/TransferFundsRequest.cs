using System;
using MediatR;
using SomeApplication.Models;

namespace Business.Accounts.Commands
{
    public class TransferFundsRequest : IRequest
    {
        public Guid ReceivingAccountId { get; set; }

        public Guid SendingAccountId { get; set; }

        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
