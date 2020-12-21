using GreenCrop.Application.Common.Interfaces;
using GreenCrop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace GreenCrop.Application.Services {
    public class TransactionCreationService : ITransactionCreationService {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public TransactionCreationService(IApplicationDbContext context, IDateTime dateTime) {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<Transaction> SetInitialBalance(Account account, double initialCredit, CancellationToken cancellationToken = new CancellationToken()) {
            account.Balance = initialCredit;
            var transaction = new Transaction {
                Account = account,
                Message = string.Format("Initial balance set to {0}", initialCredit),
                Created = _dateTime.Now
            };
            var createdTransaction = _context.Transactions.Add(transaction).Entity;
            await _context.SaveChangesAsync(cancellationToken);
            return createdTransaction;
        }
    }
}
