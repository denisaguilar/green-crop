using GreenCrop.Application.Common.Interfaces;
using GreenCrop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace GreenCrop.Application.Services {
    public class TransactionCreationService : ITransactionCreationService {
        private readonly IApplicationDbContext _context;
        public TransactionCreationService(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<Transaction> SetInitialBalance(Account account, double initialCredit, CancellationToken cancellationToken = new CancellationToken()) {
            account.Balance = initialCredit;
            var transaction = new Transaction {
                Account = account,
                Message = string.Format("Initial balance set to {0}", initialCredit)
            };
            var createdTransaction = _context.Transactions.Add(transaction).Entity;
            await _context.SaveChangesAsync(cancellationToken);
            return createdTransaction;
        }
    }
}
