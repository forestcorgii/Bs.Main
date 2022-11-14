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
    public class PayeeConfiguration : IEntityTypeConfiguration<Payee>
    {
        public void Configure(EntityTypeBuilder<Payee> builder)
        {
            builder.HasKey(ts => ts.Id);

            builder.Property(cc => cc.PayeeName).HasColumnType("VARCHAR(200)").IsRequired();
            builder.Property(cc => cc.OwnerName).HasColumnType("VARCHAR(200)");
            builder.Property(cc => cc.Address).HasColumnType("TEXT");
            builder.Property(cc => cc.Tin).HasColumnType("VARCHAR(20)");

            builder.Property(cc => cc.DateCreated).HasColumnType("TIMESTAMP");

        }
    }
}
