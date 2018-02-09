using Business.Accounts.Models;
using MediatR;

namespace Business.Accounts.Commands
{
    public class CreateAccountCommand : IRequest<AccountModel>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
