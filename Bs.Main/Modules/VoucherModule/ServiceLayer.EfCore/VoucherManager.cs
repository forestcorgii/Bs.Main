using Bs.Main.Persistence.DbContexts;
using Bs.Main.Modules.VoucherModule.Entities;
using Bs.Main.Modules.VoucherModule.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.VoucherModule.ServiceLayer.EfCore
{
    public class VoucherManager
    {
        public IDbContextFactory<MainContext> Factory;
        public VoucherManager(IDbContextFactory<MainContext> factory)
        {
            Factory = factory;
        }


        public void SaveVoucher(Voucher voucher)
        {
            using MainContext context = Factory.CreateDbContext();
            if (context.Vouchers.Any(v => v.Id == voucher.Id))
                context.Update(voucher);
            else
                context.Add(voucher);
            context.SaveChanges();

            SaveJournalEntries(voucher.JournalEntries, voucher.Id);
        }

        public void SaveJournalEntries(IEnumerable<JournalEntry> entries, Guid voucherId)
        {
            using MainContext context = Factory.CreateDbContext();
            foreach (JournalEntry entry in entries)
            {
                entry.VoucherId = voucherId;
                if (entry.Id == 0)
                    context.JournalEntries.Add(entry);
                else context.JournalEntries.Update(entry);
            }
            context.SaveChanges();

        }


    }
}
