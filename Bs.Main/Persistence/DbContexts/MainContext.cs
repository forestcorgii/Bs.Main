using Bs.Main.Modules.MasterlistModule.ValueObjects;
using Bs.Main.Modules.VoucherModule.Entities;
using Bs.Main.Modules.VoucherModule.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Persistence.DbContexts
{
    public class MainContext : DbContext
    {
        public DbSet<Voucher> Vouchers => Set<Voucher>();
        public DbSet<JournalEntry> JournalEntries => Set<JournalEntry>();

        public DbSet<Company> Companies => Set<Company>();
        public DbSet<CompanyAccount> CompanyAccounts => Set<CompanyAccount>();

        public DbSet<Payee> Payees => Set<Payee>();
        public DbSet<PayeeAccount> PayeeAccounts => Set<PayeeAccount>();

        public DbSet<JournalAccount> JournalAccounts => Set<JournalAccount>();

        public MainContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyAccountConfiguration());
            modelBuilder.ApplyConfiguration(new PayeeConfiguration());
            modelBuilder.ApplyConfiguration(new PayeeAccountConfiguration());
            modelBuilder.ApplyConfiguration(new JournalAccountConfiguration());
            modelBuilder.ApplyConfiguration(new VoucherConfiguration());
            modelBuilder.ApplyConfiguration(new JournalEntryConfiguration());
        }


        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (EntityEntry entry in entries)
            {
                if (entry.Entity is Company)
                {
                    //((Company)entry.Entity).DateModified = DateTime.Now;
                    if (entry.State == EntityState.Added)
                        ((Company)entry.Entity).DateCreated = DateTime.Now;
                }
                else if (entry.Entity is CompanyAccount)
                {
                    //((CompanyAccount)entry.Entity).DateModified = DateTime.Now;
                    if (entry.State == EntityState.Added)
                        ((CompanyAccount)entry.Entity).DateCreated = DateTime.Now;
                }
                else if (entry.Entity is Payee)
                {
                    //((Payee)entry.Entity).DateModified = DateTime.Now;
                    if (entry.State == EntityState.Added)
                        ((Payee)entry.Entity).DateCreated = DateTime.Now;
                }
                else if (entry.Entity is PayeeAccount)
                {
                    //((PayeeAccount)entry.Entity).DateModified = DateTime.Now;
                    if (entry.State == EntityState.Added)
                        ((PayeeAccount)entry.Entity).DateCreated = DateTime.Now;
                }
                //else if (entry.Entity is JournalAccount)
                //{
                //    ((JournalAccount)entry.Entity).DateModified = DateTime.Now;
                //    if (entry.State == EntityState.Added)
                //        ((JournalAccount)entry.Entity).DateCreated = DateTime.Now;
                //}
            }

            return base.SaveChanges();
        }
    }
}
