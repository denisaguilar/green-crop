using GreenCrop.Application.Common.Interfaces;
using GreenCrop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GreenCrop.Infrastructure.Persistence {
    public class ApplicationDbContext : DbContext, IApplicationDbContext {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken) {
           return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
