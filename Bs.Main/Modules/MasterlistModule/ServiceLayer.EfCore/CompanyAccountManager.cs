using Bs.Main.Persistence.DbContexts;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.MasterlistModule.ServiceLayer.EfCore
{
    public class CompanyAccountManager
    {
        private IDbContextFactory<MainContext> Factory;

        public CompanyAccountManager(IDbContextFactory<MainContext> factory) => Factory = factory;



        public IEnumerable<CompanyAccount> GetCompanyAccounts()
        {
            using var context = Factory.CreateDbContext();
            return context.CompanyAccounts.ToList();
        }



        public void SaveCompanyAccount(CompanyAccount companyAccount)
        {
            companyAccount.Validate();
            using MainContext context = Factory.CreateDbContext();
            if (context.CompanyAccounts.Any(c => c.Id == companyAccount.Id))
                context.Update(companyAccount);
            else
                context.Add(companyAccount);
            context.SaveChanges();
        }


    }
}
