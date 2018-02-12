using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Accounts.Models
{
    public class FundsModel
    {
        //Forgive me
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Amount { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Currency { get; set; }
    }
}
