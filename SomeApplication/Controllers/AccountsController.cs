using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Business.Accounts.Commands;
using Business.Accounts.Queries;
using MediatR;
using SomeApplication.Models;

namespace SomeApplication.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountsController : BaseController
    {
        public AccountsController(IMediator mediator) : base(mediator)
        {
        }

        [Route("{id}")]
        [ResponseType(typeof(AccountModel))]
        public async Task<IHttpActionResult> GetAccount(Guid id)
        {
            var request = new GetAccountRequest { AccountId = id };

            return await Handle<GetAccountRequest, GetAccountResponse>(request, response => Ok(
            new AccountModel
            {
                Id = response.AccountId,
                Balance = response.Balance,
                Currency = response.Currency
            }));
        }

        [Route("transfers")]
        public async Task<IHttpActionResult> PostTransfer(TransferFundsModel model)
        {
            var request = new TransferFundsRequest
            {
                Amount = model.Funds.Amount,
                Currency = model.Funds.Currency,
                ReceivingAccountId = model.ReceivingAccountId,
                SendingAccountId = model.SendingAccountId
            };

            return await Handle(request, Ok);
        }

        [Route("{id}/credits")]
        public async Task<IHttpActionResult> PostCredit(Guid id)
        {
            var request = new GetAccountRequest { AccountId = id };

            return await Handle<GetAccountRequest, GetAccountResponse>(request, response => StatusCode(HttpStatusCode.Created));
        }

        [Route("{id}/debits")]
        public async Task<IHttpActionResult> PostDebits(Guid id)
        {
            var request = new GetAccountRequest { AccountId = id };

            return await Handle<GetAccountRequest, GetAccountResponse>(request, response => StatusCode(HttpStatusCode.Created));
        }
    }
}