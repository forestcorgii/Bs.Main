using Bs.Main.Modules.VoucherModule.Entities;
using Bs.Main.Modules.VoucherModule.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Persistence.DbContexts
{
    public class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.VoucherNumber).HasColumnType("VARCHAR(20)");
            builder.Property(v => v.EntryDate).HasColumnType("DATE");
            builder.Property(v => v.PayeeId);
            builder.Property(v => v.PayeeAccountId).HasColumnType("INT");
            builder.Property(v => v.CompanyId).HasColumnType("VARCHAR(10)");
            builder.Property(v => v.CompanyAccountCode).HasColumnType("VARCHAR(10)");
            builder.Property(v => v.Remarks).HasColumnType("TEXT");

            builder.Property(v => v.DateCreated).HasColumnType("DATETIME");
            builder.Property(v => v.DateModified).HasColumnType("DATETIME");
        }
    }
}
