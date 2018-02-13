using System;
using System.Threading.Tasks;
using Business.Accounts.Commands;
using Business.Accounts.Models;
using Business.Accounts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Accounts.Controllers
{
    [Route("api/accounts")]
    public class AccountsController : BaseController
    {
        public AccountsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet, Route("{id:int}")]
        public async Task<IActionResult> Get(GetAccountQuery query)
        {
            return await Handle<GetAccountQuery, AccountModel>(query, Ok);
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> Post(CreateAccountCommand command)
        {
            return await Handle<CreateAccountCommand, AccountModel>(command, result => Created($"api/accounts/{result.AccountId}", result));
        }

        [HttpPost, Route("{id:int}/credits")]
        public async Task<IActionResult> PostCredit(CreateCreditCommand command)
        {
            return await Handle<CreateCreditCommand, FundsModel>(command, result => Ok(result));
        }

        [HttpPost, Route("transfers")]
        public async Task<IActionResult> PostTransfer([FromBody]CreateTransferCommand command)
        {
            return await Handle<CreateTransferCommand, FundsModel>(command, result => Ok(result));
        }

        [HttpPost, Route("{id:int}/debits")]
        public async Task<IActionResult> PostDebit(CreateDebitCommand command)
        {
            return await Handle<CreateDebitCommand, FundsModel>(command, result => Ok(result));
        }

    }
}