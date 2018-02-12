using System.Threading.Tasks;
using Business.Accounts.Models;
using Domain.Accounts;
using Highway.Data;
using Mapping;
using MediatR;

namespace Business.Accounts.Commands
{
    public class CreateAccountHandler : AsyncRequestHandler<CreateAccountCommand, AccountModel>
    {
        private readonly IAccountFactory factory;
        private readonly IWriteOnlyUnitOfWork unitOfWork;
        private readonly IMapper<Account, AccountModel> mapper;

        public CreateAccountHandler(
            IWriteOnlyUnitOfWork unitOfWork,
            IAccountFactory factory,
            IMapper<Account, AccountModel> mapper)
        {
            this.factory = factory;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        protected override async Task<AccountModel> HandleCore(CreateAccountCommand request)
        {
            var account = factory.Build(new AccountHolder(new FirstName(request.FirstName), new LastName(request.LastName)));

            unitOfWork.Add(account);
            await unitOfWork.CommitAsync();

            return mapper.Map(account);
        }
    }
}
