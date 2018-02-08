using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Business.Accounts.Models
{
    public class CreateCreditCommand : IRequest<TransactionModel>
    {
        [FromRoute(Name = "id")]
        public int AccountId { get; set; }

        [FromBody]
        public FundsModel Funds { get; set; }
    }
}
