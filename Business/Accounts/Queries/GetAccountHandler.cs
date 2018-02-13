using System.Threading.Tasks;
using Business.Accounts.Models;
using Business.Exceptions;
using Domain.Accounts;
using Highway.Data;
using Mapping;
using MediatR;
using Persistence.Accounts.Queries;

namespace Business.Accounts.Queries
{
    public class GetAccountHandler : AsyncRequestHandler<GetAccountQuery, AccountModel>
    {
        private readonly IReadOnlyRepository repo;
        private readonly IMapper<Account, AccountModel> mapper;

        public GetAccountHandler(
            IReadOnlyRepository repo,
            IMapper<Account, AccountModel> mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        protected override async Task<AccountModel> HandleCore(GetAccountQuery request)
        {
            var account = await repo.FindAsync(new GetById(new AccountId(request.Id)));

            if(account == null)
            {
                throw new BadRequestException("Account was not found");
            }

            return mapper.Map(account);
        }
    }
}