using System.Threading.Tasks;
using Business.Exceptions;
using Domain.Accounts;
using Highway.Data;
using MediatR;
using Persistence.Accounts.Queries;

namespace Business.Accounts.Commands
{
    public class CreditFundsHandler : AsyncRequestHandler<CreditFundsRequest>
    {
        private readonly IRepository repo;

        public CreditFundsHandler(IRepository repo)
        {
            this.repo = repo;
        }

        protected override async Task HandleCore(CreditFundsRequest request)
        {
            var accountId = new AccountId(request.Id);
            var funds = new Funds(request.Currency, request.Amount);

            var account = await repo.FindAsync(new GetById(accountId));

            if (account == null)
            {
                throw new BadRequestException("Account not found");
            }

            account.Credit(funds);

            repo.Context.Update(account);
            await repo.Context.CommitAsync();
        }
    }
}
