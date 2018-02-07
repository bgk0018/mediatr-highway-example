using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Exceptions;
using Domain.Accounts;
using Highway.Data;
using MediatR;
using Persistence.Accounts.Queries;

namespace Business.Accounts.Commands
{
    public class DebitFundsHandler : AsyncRequestHandler<DebitFundsRequest>
    {
        private readonly IRepository repo;

        public DebitFundsHandler(IRepository repo)
        {
            this.repo = repo;
        }

        protected override async Task HandleCore(DebitFundsRequest request)
        {
            var accountId = new AccountId(request.Id);
            var funds = new Funds(request.Currency, request.Amount);

            var account = await repo.FindAsync(new GetById(accountId));

            if (account == null)
            {
                throw new BadRequestException("Account not found");
            }

            account.Debit(funds);

            if (account.Balance.IsNegative)
            {
                throw new BadRequestException("Insufficent Funds");
            }

            repo.Context.Update(account);
            await repo.Context.CommitAsync();
        }
    }
}
