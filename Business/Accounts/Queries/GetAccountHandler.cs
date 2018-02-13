using System.Threading.Tasks;
using Business.Accounts.Models;
using Business.Exceptions;
using Domain.Accounts;
using Highway.Data;
using MediatR;
using Persistence.Accounts.Queries;

namespace Business.Accounts.Queries
{
    public class GetAccountHandler : AsyncRequestHandler<GetAccountQuery, AccountModel>
    {
        private readonly IReadOnlyRepository repo;

        public GetAccountHandler(IReadOnlyRepository repo)
        {
            this.repo = repo;
        }

        protected override async Task<AccountModel> HandleCore(GetAccountQuery request)
        {
            var account = await repo.FindAsync(new GetById(new AccountId(request.Id)));

            if(account == null)
            {
                throw new BadRequestException("Account was not found");
            }

            return new AccountModel()
            {
                AccountId = account.Id,
                Balance = account.Balance.Amount,
                Currency = account.Balance.Currency.ToString(),
                LastName = account.Holder.LastName,
                FirstName = account.Holder.FirstName
            };
        }
    }
}