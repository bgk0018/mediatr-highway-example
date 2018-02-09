using Domain.Accounts;
using FluentValidation;
using Highway.Data;
using Persistence.Accounts.Queries;

namespace Business.Accounts.Commands
{
    public class CreateCreditValidator : AbstractValidator<CreateCreditCommand>
    {
        protected CreateCreditValidator(IReadOnlyRepository repo)
        {

            RuleFor(p => 
                repo.FindAsync(
                    new GetById(
                        new AccountId(p.AccountId))))
                .NotNull();
        }
    }
}
