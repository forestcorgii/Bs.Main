using Bs.Main.Modules.MasterlistModule.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Persistence.DbContexts
{
    public class CompanyAccountConfiguration : IEntityTypeConfiguration<CompanyAccount>
    {
        public void Configure(EntityTypeBuilder<CompanyAccount> builder)
        {
            builder.HasKey(ts => ts.Id);

            builder.Property(cc => cc.CompanyId).HasColumnType("VARCHAR(20)");
            builder.Property(cc => cc.Code).HasColumnType("VARCHAR(10)");
            builder.Property(cc => cc.BankName).HasColumnType("VARCHAR(10)");
            builder.Property(cc => cc.AccountNumber).HasColumnType("VARCHAR(25)");

            builder.Property(cc => cc.DateCreated).HasColumnType("TIMESTAMP");

        }
    }
}
