using System.ComponentModel.DataAnnotations;
using Business.Accounts.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Business.Accounts.Commands
{
    public class CreateDebitCommand : IRequest<FundsModel>
    {
        [FromRoute(Name = "id")]
        public int AccountId { get; set; }

        [FromBody]
        [Required]
        public FundsModel Funds { get; set; }
    }
}
