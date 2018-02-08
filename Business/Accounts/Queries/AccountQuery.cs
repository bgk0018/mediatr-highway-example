using System;
using Business.Accounts.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Business.Accounts.Queries
{
    public class AccountQuery : IRequest<AccountModel>
    {
        [FromRoute]
        public int Id { get; set; }
    }
}
