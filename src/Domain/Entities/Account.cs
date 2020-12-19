using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenCrop.Domain.Entities {
    public class Account {
        public string Id { get; set; }
        public double Balance { get; set; }

        public Customer Customer { get; set; }
        public string CustomerId { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
