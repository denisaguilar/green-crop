﻿using GreenCrop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenCrop.Infrastructure.Persistence.Configuration {
    public class AccountConfiguration : IEntityTypeConfiguration<Account> {
        public void Configure(EntityTypeBuilder<Account> builder) {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)                
                .ValueGeneratedOnAdd();
        }
    }
}
