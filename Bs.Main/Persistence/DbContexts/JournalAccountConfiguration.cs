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
    public class JournalAccountConfiguration : IEntityTypeConfiguration<JournalAccount>
    {
        public void Configure(EntityTypeBuilder<JournalAccount> builder)
        {
            builder.HasKey(ts => ts.Id);

            builder.Property(cc => cc.Name).HasColumnType("VARCHAR(200)").IsRequired();
            builder.Property(cc => cc.Rate).HasColumnType("DOUBLE(6,2)");

        }
    }
}
