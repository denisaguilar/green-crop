﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCrop.Domain.Entities {
    public class Account {
        public string Id { get; set; }
        public double Balance { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
