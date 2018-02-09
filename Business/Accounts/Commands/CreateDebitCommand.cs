using Business.Accounts.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Business.Accounts.Commands
{
    public class CreateDebitCommand : IRequest<TransactionModel>
    {
        [FromRoute(Name = "id")]
        public int AccountId { get; set; }

        [FromBody]
        public FundsModel Funds { get; set; }
    }
}
