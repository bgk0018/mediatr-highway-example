using System.Threading.Tasks;
using Business.Accounts.Models;
using Business.Exceptions;
using Domain.Accounts;
using Highway.Data;
using MediatR;
using Persistence.Accounts.Queries;

namespace Business.Accounts.Commands
{
    public class CreateDebitHandler : AsyncRequestHandler<CreateDebitCommand, FundsModel>
    {
        private readonly IRepository repo;

        public CreateDebitHandler(IRepository repo)
        {
            this.repo = repo;
        }

        protected override async Task<FundsModel> HandleCore(CreateDebitCommand request)
        {
            var accountId = new AccountId(request.AccountId);
            var funds = new Funds(request.Funds.Currency, request.Funds.Amount);

            var account = await repo.FindAsync(new GetById(accountId));

            if (account == null)
            {
                throw new BadRequestException("Account was not found");
            }

            account.Debit(funds);

            if (account.Balance.IsNegative)
            {
                throw new BadRequestException("Insufficent Funds");
            }

            await repo.UnitOfWork.CommitAsync();

            return new FundsModel()
            {
                Amount = account.Balance.Amount,
                Currency = account.Balance.Currency.ToString()
            };
        }
    }
}