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
    public class PayeeManager
    {
        private IDbContextFactory<MainContext> Factory;

        public PayeeManager(IDbContextFactory<MainContext> factory) => Factory = factory;



        public IEnumerable<Payee> GetPayees()
        {
            using var context = Factory.CreateDbContext();
            return context.Payees.ToList();
        }



        public void SavePayee(Payee payee)
        {
            payee.Validate();
            using MainContext context = Factory.CreateDbContext();
            if (context.Payees.Any(c => c.Id == payee.Id))
                context.Update(payee);
            else
                context.Add(payee);
            context.SaveChanges();
        }

        public void RemovePayee(Payee payee)
        {
            using MainContext context = Factory.CreateDbContext();
            context.Payees.Remove(payee);
            context.SaveChanges();
        }

    }
}
