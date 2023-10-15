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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role
            {
                RoleId= 1,
                Rolename="Director"
            },
            new Role
            {
                RoleId= 2,
                Rolename="Staff"
            },
            new Role
            {
                RoleId= 3,
                Rolename="Reviewer"
            },
            new Role
            {
                RoleId= 4,
                Rolename="Author"
            }
            );
        }
    }
}
