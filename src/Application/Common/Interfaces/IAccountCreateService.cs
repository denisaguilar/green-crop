﻿using GreenCrop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GreenCrop.Application.Common.Interfaces {
    public interface IAccountCreateService {
        Task<Account> Create(Customer customer, CancellationToken cancellationToken);
    }
}
