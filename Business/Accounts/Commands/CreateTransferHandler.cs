using System.Threading.Tasks;
using Business.Accounts.Models;
using Business.Exceptions;
using Domain.Accounts;
using Highway.Data;
using MediatR;
using Persistence.Accounts.Queries;

namespace Business.Accounts.Commands
{
    public class CreateTransferHandler : AsyncRequestHandler<CreateTransferCommand, FundsModel>
    {
        private readonly IRepository repo;

        public CreateTransferHandler(IRepository repo)
        {
            this.repo = repo;
        }

        protected override async Task<FundsModel> HandleCore(CreateTransferCommand request)
        {
            var receivingAccountId = new AccountId(request.ReceivingAccountId);
            var sendingAccountId = new AccountId(request.SendingAccountId);

            var funds = new Funds(request.Funds.Currency, request.Funds.Amount);

            var receivingAccount = await repo.FindAsync(new GetById(receivingAccountId));
            var sendingAccount = await repo.FindAsync(new GetById(sendingAccountId));

            if (receivingAccount == null)
            {
                throw new BadRequestException("Account was not found");
            }

            if (sendingAccount == null)
            {
                throw new BadRequestException("Account was not found");
            }

            var transferService = new TransferFundsService();

            transferService.Transfer(sendingAccount, receivingAccount, funds);

            if (sendingAccount.Balance.IsNegative)
            {
                throw new BadRequestException("Insufficent Funds");
            }

            await repo.UnitOfWork.CommitAsync();

            return request.Funds;
        }
    }
}