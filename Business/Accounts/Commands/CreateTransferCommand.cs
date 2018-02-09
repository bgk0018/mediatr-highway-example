using Business.Accounts.Models;
using MediatR;

namespace Business.Accounts.Commands.CreateTransfer
{
    public class CreateTransferCommand : IRequest<TransactionModel>
    {
        public int ReceivingAccountId { get; set; }

        public int SendingAccountId { get; set; }

        public FundsModel Funds { get; set; }
    }
}
