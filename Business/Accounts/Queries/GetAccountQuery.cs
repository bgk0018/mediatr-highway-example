using Business.Accounts.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Business.Accounts.Queries
{
    public class GetAccountQuery : IRequest<AccountModel>
    {
        [FromRoute]
        public int Id { get; set; }
    }
}
