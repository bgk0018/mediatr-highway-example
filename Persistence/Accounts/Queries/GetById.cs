using System;
using System.Linq;
using Domain.Accounts;
using Highway.Data;

namespace Persistence.Accounts.Queries
{
    public class GetById : Scalar<Account>
    {
        public GetById(AccountId id)
        {
            ContextQuery = context => context.AsQueryable<Account>().FirstOrDefault(p => p.Id == id);
        }
    }
}