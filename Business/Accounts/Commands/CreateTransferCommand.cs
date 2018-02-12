using System.ComponentModel.DataAnnotations;
using Business.Accounts.Models;
using MediatR;

namespace Business.Accounts.Commands
{
    public class CreateTransferCommand : IRequest<FundsModel>
    {
        [Range(1, int.MaxValue)]
        public int ReceivingAccountId { get; set; }

        [Range(1, int.MaxValue)]
        public int SendingAccountId { get; set; }

        [Required]
        public FundsModel Funds { get; set; }
    }
}
