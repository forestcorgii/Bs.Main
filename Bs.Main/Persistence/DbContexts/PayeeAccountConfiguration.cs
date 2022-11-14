using Bs.Main.Modules.MasterlistModule.ValueObjects;
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
    public class PayeeAccountConfiguration : IEntityTypeConfiguration<PayeeAccount>
    {
        public void Configure(EntityTypeBuilder<PayeeAccount> builder)
        {
            builder.HasKey(ts => ts.Id);

            builder.Property(cc => cc.PayeeId).IsRequired();
            builder.Property(cc => cc.AccountNumber).HasColumnType("VARCHAR(25)");
            builder.Property(cc => cc.DefaultParticulars).HasColumnType("TEXT").HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<Dictionary<string,string>>(v)
            );

            builder.Property(cc => cc.DateCreated).HasColumnType("TIMESTAMP");

        }
    }
}
