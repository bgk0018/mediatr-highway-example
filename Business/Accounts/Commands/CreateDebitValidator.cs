using Domain.Accounts;
using FluentValidation;
using Highway.Data;
using Persistence.Accounts.Queries;

namespace Business.Accounts.Commands
{
    public class CreateDebitValidator : AbstractValidator<CreateDebitCommand>
    {
        protected CreateDebitValidator(IReadOnlyRepository repo)
        {

            RuleFor(p =>
                    repo.FindAsync(
                        new GetById(
                            new AccountId(p.AccountId))))
                .NotNull();
        }
    }
}
