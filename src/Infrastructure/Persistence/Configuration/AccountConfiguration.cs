using GreenCrop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCrop.Infrastructure.Persistence.Configuration {
    public class AccountConfiguration : IEntityTypeConfiguration<Account> {
        public void Configure(EntityTypeBuilder<Account> builder) {
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
