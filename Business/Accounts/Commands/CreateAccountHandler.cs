using System.Threading.Tasks;
using Business.Accounts.Models;
using Domain.Accounts;
using Highway.Data;
using MediatR;

namespace Business.Accounts.Commands
{
    public class CreateAccountHandler : AsyncRequestHandler<CreateAccountCommand, AccountModel>
    {
        private readonly IAccountFactory factory;
        private readonly IWriteOnlyUnitOfWork unitOfWork;

        public CreateAccountHandler(
            IWriteOnlyUnitOfWork unitOfWork,
            IAccountFactory factory)
        {
            this.factory = factory;
            this.unitOfWork = unitOfWork;
        }

        protected override async Task<AccountModel> HandleCore(CreateAccountCommand request)
        {
            var account = factory.Build(new AccountHolder(new FirstName(request.FirstName), new LastName(request.LastName)));

            unitOfWork.Add(account);
            await unitOfWork.CommitAsync();

            //TODO Mapper
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
