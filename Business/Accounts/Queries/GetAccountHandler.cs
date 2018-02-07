using System.Threading.Tasks;
using Business.Exceptions;
using Domain.Accounts;
using Highway.Data;
using MediatR;
using Persistence.Accounts.Queries;

namespace Business.Accounts.Queries
{
    public class GetAccountHandler : AsyncRequestHandler<GetAccountRequest, GetAccountResponse>
    {
        private readonly IRepository repo;

        public GetAccountHandler(IRepository repo)
        {
            this.repo = repo;
        }

        protected override async Task<GetAccountResponse> HandleCore(GetAccountRequest request)
        {
            var account = await repo.FindAsync(new GetById(new AccountId(request.AccountId)));

            if (account == null)
            {
                throw new BadRequestException("Account not found");
            }

            return new GetAccountResponse
            {
                Balance = account.Balance.Amount,
                Currency = account.Balance.Currency.ToString(),
                AccountId = account.Id.Value,
            };
        }
    }
}
