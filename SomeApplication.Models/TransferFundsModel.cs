using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeApplication.Models
{
    public class TransferFundsModel
    {
        public Guid ReceivingAccountId { get; set; }

        public Guid SendingAccountId { get; set; }

        public FundsModel Funds { get; set; }
    }
}
