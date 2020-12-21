using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCrop.Domain.Entities {
    public class Transaction {
        public string Id { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }

        public string AccountId { get; set; }
        public Account Account { get; set; }        
    }
}
