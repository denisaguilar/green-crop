using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCrop.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string Account { get; set; }
        public string AccountId { get; set; }
        public string Message { get; set; }
    }
}
