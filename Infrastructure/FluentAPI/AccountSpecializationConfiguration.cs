using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FluentAPI
{
    public class AccountSpecializationConfiguration : IEntityTypeConfiguration<AccountSpecialization>
    {
        public void Configure(EntityTypeBuilder<AccountSpecialization> builder)
        {
            builder.HasKey(x => new { x.AccountId, x.SpecializationId });
        }
    }
}
