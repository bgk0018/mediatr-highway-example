﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeApplication.Models
{
    public class AccountModel
    {
        public Guid Id { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
    }
}
