using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Persistence.DbContexts
{
    public class MainDbContextFactory : IDbContextFactory<MainContext>, IDesignTimeDbContextFactory<MainContext>
    {
        private readonly string _connectionString;
        public MainDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MainDbContextFactory()
        {
            _connectionString = "server=localhost;database=payable3Test_efdb;user=root;password=Soft1234;";
        }

        public MainContext CreateDbContext()
        {
            DbContextOptions dbContextOptions = new DbContextOptionsBuilder()
                .UseMySQL(_connectionString,
                    options => options.MigrationsHistoryTable("_MasterlistMigrationHistory")
                )
                .Options;

            return new MainContext(dbContextOptions);
        }

        public MainContext CreateDbContext(string[] args) => CreateDbContext();
    }
}
