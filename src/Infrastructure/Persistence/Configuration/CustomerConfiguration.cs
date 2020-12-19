﻿using GreenCrop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCrop.Infrastructure.Persistence.Configuration {
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer> {
        public void Configure(EntityTypeBuilder<Customer> builder) {
            builder.Property(c => c.Id)
              .ValueGeneratedOnAdd();
            builder
                .HasOne(a => a.Account)
                .WithOne(c => c.Customer)
                .HasForeignKey<Account>(a => a.CustomerId);              
        }
    }
}
