using Domain.Accounts;
using FluentValidation;
using Highway.Data;
using Persistence.Accounts.Queries;

namespace Business.Accounts.Commands.CreateTransfer
{
    public class CreateTransferValidator : AbstractValidator<CreateTransferCommand>
    {
        protected CreateTransferValidator(IReadOnlyRepository repo)
        {

            RuleFor(p =>
                    repo.FindAsync(
                        new GetById(
                            new AccountId(p.ReceivingAccountId))))
                .NotNull();

            RuleFor(p =>
                    repo.FindAsync(
                        new GetById(
                            new AccountId(p.SendingAccountId))))
                .NotNull();
        }
    }
}
