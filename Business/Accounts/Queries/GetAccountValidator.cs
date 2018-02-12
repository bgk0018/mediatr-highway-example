using Domain.Accounts;
using FluentValidation;
using Highway.Data;
using Persistence.Accounts.Queries;

namespace Business.Accounts.Queries
{
    public class GetAccountValidator : AbstractValidator<GetAccountQuery>
    {
        public GetAccountValidator(IReadOnlyRepository repo)
        {
            RuleFor(p => 
                repo.Find(
                    new GetById(
                        new AccountId(p.Id))))
                .NotNull()
                .WithMessage("Account not found with that id.");
        }
    }
}
