using Bs.Main.Modules.MasterlistModule.ValueObjects;
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
    public class VoucherProvider
    {
        public IDbContextFactory<MainContext> Factory;

        public VoucherProvider(IDbContextFactory<MainContext> factory)
        {
            Factory = factory;
        }

        public IEnumerable<Voucher> GetVouchers()
        {
            using MainContext context = Factory.CreateDbContext();
            return context.Vouchers
                .Include(v => v.Company)
                .Include(v => v.Payee)
                .Include(v => v.PayeeAccount)
                .Include(v => v.JournalEntries)
                .ToList();
        }



        public Company FirstVoucher()
        {
            using MainContext context = Factory.CreateDbContext();
            return context.Companies.FirstOrDefault();
        }

        public Company FirstCompany()
        {
            using MainContext context = Factory.CreateDbContext();
            return context.Companies.FirstOrDefault();
        }

        public CompanyAccount FirstCompanyAccount()
        {
            using MainContext context = Factory.CreateDbContext();
            return context.CompanyAccounts.FirstOrDefault();
        }

        public Payee FirstPayee()
        {
            using MainContext context = Factory.CreateDbContext();
            return context.Payees.FirstOrDefault();
        }

        public PayeeAccount FirstPayeeAccount()
        {
            using MainContext context = Factory.CreateDbContext();
            return context.PayeeAccounts.FirstOrDefault();
        }

        public JournalAccount FirstJournalAccount()
        {
            using MainContext context = Factory.CreateDbContext();
            return context.JournalAccounts.FirstOrDefault();
        }

    }
}
