using System.Threading.Tasks;
using Business.Accounts.Models;
using Domain.Accounts;
using Highway.Data;
using MediatR;
using Persistence.Accounts.Queries;

namespace Business.Accounts.Commands
{
    public class CreateCreditHandler : AsyncRequestHandler<CreateCreditCommand, TransactionModel>
    {
        private readonly IRepository repo;

        public CreateCreditHandler(IRepository repo)
        {
            this.repo = repo;
        }

        protected override async Task<TransactionModel> HandleCore(CreateCreditCommand request)
        {
            var accountId = new AccountId(request.AccountId);
            var funds = new Funds(request.Funds.Currency, request.Funds.Amount);

            var account = await repo.FindAsync(new GetById(accountId));

            account.Credit(funds);

            //Is the account retrieved tracked somehow from beta?
            await repo.UnitOfWork.CommitAsync();

            return new TransactionModel();
        }
    }
}