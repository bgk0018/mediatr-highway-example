using System.Threading.Tasks;
using Business.Exceptions;
using Domain.Accounts;
using Highway.Data;
using MediatR;
using Persistence.Accounts.Queries;

namespace Business.Accounts.Commands
{
    public class TransferFundsHandler : AsyncRequestHandler<TransferFundsRequest>
    {
        private readonly IRepository repo;

        public TransferFundsHandler(IRepository repo)
        {
            this.repo = repo;
        }
        protected override async Task HandleCore(TransferFundsRequest request)
        {
            var receivingAccountId = new AccountId(request.ReceivingAccountId);
            var sendingAccountId = new AccountId(request.SendingAccountId);

            var funds = new Funds(request.Currency, request.Amount);

            var receivingAccount = await repo.FindAsync(new GetById(receivingAccountId));
            var sendingAccount = await repo.FindAsync(new GetById(sendingAccountId));

            if (receivingAccount == null)
            {
                throw new BadRequestException("Receiving account not found");
            }

            if (sendingAccount == null)
            {
                throw new BadRequestException("Sending account not found");
            }

            var transferService = new TransferFundsService();

            transferService.Transfer(sendingAccount, receivingAccount, funds);

            if (sendingAccount.Balance.IsNegative)
            {
                throw new BadRequestException("Insufficent Funds");
            }

            repo.Context.Update(receivingAccount);
            repo.Context.Update(sendingAccount);

            await repo.Context.CommitAsync();
        }
    }
}
