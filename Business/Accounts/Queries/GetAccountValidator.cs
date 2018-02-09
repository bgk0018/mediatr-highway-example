using Domain.Accounts;
using FluentValidation;
using Highway.Data;
using Persistence.Accounts.Queries;

namespace Business.Accounts.Queries
{
    public class GetAccountValidator : AbstractValidator<GetAccountQuery>
    {
        protected GetAccountValidator(IReadOnlyRepository repo)
        {

            RuleFor(p =>
                    repo.FindAsync(
                        new GetById(
                            new AccountId(p.Id))))
                .NotNull();
        }
    }
}
