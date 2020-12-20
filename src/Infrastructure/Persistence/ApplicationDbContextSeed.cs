using GreenCrop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCrop.Infrastructure.Persistence {
    public static class ApplicationDbContextSeed {
        
        public static async Task SeedData(ApplicationDbContext context) {
            context.Customers.AddRange(new HashSet<Customer> {
                new Customer{
                    Id = "74ff61a7-dcbd-4438-9775-7e1a5ad26261",
                    Name = "John",
                    Surname = "Doe",
                },
                new Customer{
                    Id = "5af4eb21-8900-451d-a887-5af0be5615c5",
                    Name = "Jane",
                    Surname = "Doe",
                }
            });
            await context.SaveChangesAsync();
        }
    }
}
