using GreenCrop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCrop.Application.Common.Interfaces {
    public interface IAccountCreateService {
        Account Create(string customerId);
    }
}
