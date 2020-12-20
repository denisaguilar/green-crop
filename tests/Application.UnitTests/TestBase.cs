using GreenCrop.Domain.Entities;
using GreenCrop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests {
    public abstract class TestBase {
        private const string DatabaseName = "TestMemoryDB";

        protected DbContextOptions<ApplicationDbContext> ContextOptions { get; }

        public TestBase() {
            ContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(DatabaseName).Options;
            Seed();
        }

        public void Seed() {
            using var context = new ApplicationDbContext(ContextOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Customers.Add(new Customer {
                Id = "cea42e0d-feab-496b-8c9e-97bbc25f6230",
                Name = "John",
                Surname = "Doe"
            });

            context.SaveChanges();
        }
    }
}
