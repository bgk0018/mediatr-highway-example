using System;
using System.Threading.Tasks;
using Business.Exceptions;
using Domain.Accounts;
using Highway.Data;
using MediatR;
using Persistence.Accounts.Queries;

namespace Business.Accounts.Commands
{
    public class DeleteAccountHandler : AsyncRequestHandler<DeleteAccountCommand>
    {
        private readonly IRepository repo;

        public DeleteAccountHandler(IRepository repo)
        {
            this.repo = repo;
        }

        protected override async Task HandleCore(DeleteAccountCommand request)
        {
            var account = await repo.FindAsync(new GetById(new AccountId(request.Id)));

            if (account == null)
            {
                throw new BadRequestException("Account was not found.");
            }

            repo.UnitOfWork.Remove(account);
            await repo.UnitOfWork.CommitAsync();
        }
    }
}
