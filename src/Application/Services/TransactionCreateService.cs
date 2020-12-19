using GreenCrop.Application.Common.Interfaces;
using GreenCrop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace GreenCrop.Application.Services {
    public class TransactionCreateService : ITransactionCreateService {
        private readonly IApplicationDbContext _context;
        public TransactionCreateService(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<Transaction> SetInitialBalance(Account account, double initialBalance, CancellationToken cancellationToken) {
            var transaction = new Transaction {
            };
            var createdTransaction = _context.Transactions.Add(transaction).Entity;
            await _context.SaveChangesAsync(cancellationToken);
            return createdTransaction;
        }
    }
}
