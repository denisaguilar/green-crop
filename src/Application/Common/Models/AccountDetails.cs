using System.Collections.Generic;

namespace GreenCrop.Application.Common.Models {
    public class AccountDetails {
        public string Id { get; set; }
        public double Balance { get; set; }

        public List<TransactionDetails> Transactions{ get; set; }
    }
}
