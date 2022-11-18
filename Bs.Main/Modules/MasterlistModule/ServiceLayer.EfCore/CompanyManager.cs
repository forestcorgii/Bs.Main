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
    public class CompanyManager
    {
        private IDbContextFactory<MainContext> Factory;

        public CompanyManager(IDbContextFactory<MainContext> factory) => Factory = factory;



        public IEnumerable<Company> GetCompanies()
        {
            using var context = Factory.CreateDbContext();
            return context.Companies.Include(c => c.CompanyAccounts).ToList();
        }


        public void SaveCompany(Company company)
        {
            company.Validate();
            using MainContext context = Factory.CreateDbContext();
            if (context.Companies.Any(c => c.Id == company.Id))
                context.Update(company);
            else
                context.Add(company);

            context.SaveChanges();
        }

        public void RemoveCompany(Company company)
        {
            using MainContext context = Factory.CreateDbContext();
            context.Companies.Remove(company);
            context.SaveChanges();
        }

    }
}
