using GreenCrop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace GreenCrop.Application.Common.Interfaces {
    public interface ITransactionCreationService {
        Task<Transaction> SetInitialBalance(Account account, double initialCredit, CancellationToken cancellationToken);
    }
}
