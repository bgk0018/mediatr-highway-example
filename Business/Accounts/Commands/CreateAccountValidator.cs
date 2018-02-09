using FluentValidation;

namespace Business.Accounts.Commands
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountCommand>
    {
        protected CreateAccountValidator()
        {
        }
    }
}
