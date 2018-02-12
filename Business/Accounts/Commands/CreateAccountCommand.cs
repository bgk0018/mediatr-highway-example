using System.ComponentModel.DataAnnotations;
using Business.Accounts.Models;
using MediatR;

namespace Business.Accounts.Commands
{
    public class CreateAccountCommand : IRequest<AccountModel>
    {
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
    }
}
