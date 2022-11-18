using Bs.Main.Modules.VoucherModule.Entities;
using Bs.Main.Modules.VoucherModule.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Persistence.DbContexts
{
    public class JournalEntryConfiguration : IEntityTypeConfiguration<JournalEntry>
    {
        public void Configure(EntityTypeBuilder<JournalEntry> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.CompanyId).HasColumnType("VARCHAR(45)");
            builder.Property(v => v.VoucherId);
            builder.Property(v => v.JournalAccountName).HasColumnType("VARCHAR(45)");
            builder.Property(v => v.WithholdingTaxRate).HasColumnType("DOUBLE(4,2)");
            builder.Property(v => v.Amount).HasColumnType("DOUBLE(10,2)");

            builder.Property(v => v.Particulars).HasColumnType("TEXT").HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<ObservableCollection<ParticularsKeyValue>>(v)
            );
        }
    }
}
