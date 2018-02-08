using System.Threading.Tasks;
using Business.Accounts.Models;
using Business.Exceptions;
using Domain.Accounts;
using Highway.Data;
using MediatR;
using Persistence.Accounts.Queries;

namespace Business.Accounts.Queries
{
    public class GetAccountHandler : AsyncRequestHandler<AccountQuery, AccountModel>
    {
        private readonly IRepository repo;

        public GetAccountHandler(IRepository repo)
        {
            this.repo = repo;
        }

        protected override async Task<AccountModel> HandleCore(AccountQuery request)
        {
            var account = await repo.FindAsync(new GetById(new AccountId(request.Id)));

            if (account == null)
            {
                throw new BadRequestException("Account not found");
            }

            return new AccountModel
            {
                Balance = account.Balance.Amount,
                Currency = account.Balance.Currency.ToString(),
                AccountId = account.Id.Value
            };
        }
    }
}