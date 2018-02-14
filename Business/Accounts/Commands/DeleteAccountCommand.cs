using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Business.Accounts.Commands
{
    public class DeleteAccountCommand : IRequest
    {
        [FromRoute(Name="id")]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}
