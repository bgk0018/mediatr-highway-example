using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Business.Accounts.Models
{
    public class CreateDebitCommand : IRequest<TransactionModel>
    {
        [FromRoute(Name = "id")]
        public int AccountId { get; set; }

        [FromBody]
        public FundsModel Funds { get; set; }
    }
}
