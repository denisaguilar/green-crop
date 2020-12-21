using GreenCrop.Domain.Entities;
using System.Collections.Generic;

namespace GreenCrop.Application.Common.Models {
    public class CustomerDetails {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<AccountDetails> Accounts { get; set; }
    }
}
