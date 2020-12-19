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

        public async Task<Transaction> SetInitialBalance(Account account, double initialCredit, CancellationToken cancellationToken) {
            account.Balance = initialCredit;
            var msg = string.Format("updated initial balance to {0}", initialCredit);
            var transaction = new Transaction {
                Account = account,
                Message = msg
            };
            var createdTransaction = _context.Transactions.Add(transaction).Entity;
            await _context.SaveChangesAsync(cancellationToken);
            return createdTransaction;
        }
    }
}
