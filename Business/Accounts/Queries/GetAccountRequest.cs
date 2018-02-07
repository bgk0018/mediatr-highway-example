using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Business.Accounts.Queries
{
    public class GetAccountRequest : IRequest<GetAccountResponse>
    {
        public Guid AccountId { get; set; }
    }
}
