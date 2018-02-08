﻿using System.Threading.Tasks;
using Business.Accounts.Models;
using Business.Exceptions;
using Domain.Accounts;
using Highway.Data;
using MediatR;
using Persistence.Accounts.Queries;

namespace Business.Accounts.Commands
{
    public class CreateDebitHandler : AsyncRequestHandler<CreateDebitCommand, TransactionModel>
    {
        private readonly IRepository repo;

        public CreateDebitHandler(IRepository repo)
        {
            this.repo = repo;
        }

        protected override async Task<TransactionModel> HandleCore(CreateDebitCommand request)
        {
            var accountId = new AccountId(request.AccountId);
            var funds = new Funds(request.Funds.Currency, request.Funds.Amount);

            var account = await repo.FindAsync(new GetById(accountId));

            if (account == null) throw new BadRequestException("Account not found");

            account.Debit(funds);

            if (account.Balance.IsNegative) throw new BadRequestException("Insufficent Funds");

            repo.Context.Update(account);
            await repo.Context.CommitAsync();

            return new TransactionModel();
        }
    }
}