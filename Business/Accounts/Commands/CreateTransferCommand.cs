using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Business.Accounts.Models
{
    public class CreateTransferCommand : IRequest<TransactionModel>
    {
        public int ReceivingAccountId { get; set; }

        public int SendingAccountId { get; set; }

        public FundsModel Funds { get; set; }
    }
}
