using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCrop.Domain.Entities {
    public class Customer {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Account Account { get; set; }
        public string AccountId { get; set; }
    }
}
