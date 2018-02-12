using System;
using Business.Accounts.Models;
using Domain.Accounts;
using Mapping;

namespace Business.Accounts.Mappers
{
    public class AccountMapper : IMapper<Account, AccountModel>
    {
        public AccountModel Map(Account source)
        {
            return new AccountModel()
            {
                AccountId = source.Id,
                Balance = source.Balance.Amount,
                Currency = source.Balance.Currency.ToString(),
                LastName = source.Holder.LastName,
                FirstName = source.Holder.FirstName
            };
        }
    }
}
