using System;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Get(AccountQuery query)
        {
            return await Handle<AccountQuery, AccountModel>(query, Ok);
        }

        [HttpPost, Route("{id:int}/credits")]
        public async Task<IActionResult> PostCredit(CreateCreditCommand model)
        {
            return await Handle<CreateCreditCommand, TransactionModel>(model, result => Created(new Uri("SomeRoute/Not/Important"), result));
        }

        [HttpPost, Route("transfers")]
        public async Task<IActionResult> PostTransfer([FromBody]CreateTransferCommand model)
        {
            return await Handle<CreateTransferCommand, TransactionModel>(model, result => Created(new Uri("SomeRoute/Not/Important"), result));
        }

        [HttpPost, Route("{id:int}/debits")]
        public async Task<IActionResult> PostDebits(CreateDebitCommand model)
        {
            return await Handle<CreateDebitCommand, TransactionModel>(model, result => Created(new Uri("SomeRoute/Not/Important"), result));
        }

    }
}