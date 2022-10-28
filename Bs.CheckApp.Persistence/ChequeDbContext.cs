using Bs.CheckApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bs.CheckApp.Persistence
{
    public class ChequeDbContext : DbContext
    {
        public DbSet<Cheque> Cheques => Set<Cheque>();
        public DbSet<ChequeBook> ChequeBooks => Set<ChequeBook>();

        public ChequeDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChequeBook>().ToTable("cheque_book").HasKey(cb => cb.Id);
            modelBuilder.ApplyConfiguration(new ChequeConfiguration());
        }

    }
}
