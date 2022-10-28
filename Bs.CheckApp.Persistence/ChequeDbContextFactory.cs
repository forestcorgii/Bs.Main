using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.CheckApp.Persistence
{
    public class ChequeDbContextFactory : IDbContextFactory<ChequeDbContext>, IDesignTimeDbContextFactory<ChequeDbContext>
    {

        private string _connectionString { get; set; }

        public ChequeDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ChequeDbContextFactory() =>
            _connectionString = "server=localhost;database=bookkeeping_efdb;user=root;password=Soft1234;";

        public ChequeDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder()
                //.UseMySQL(_connectionString, options => options.MigrationsHistoryTable("_ChequeMigrationHistory"))
                .UseSqlite("Data Source=checkApp.db;")
                .Options;

            return new ChequeDbContext(options);
        }

        public ChequeDbContext CreateDbContext(string[] args) => CreateDbContext();
    }
}
