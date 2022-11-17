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
    public class PayeeAccountManager
    {

        private IDbContextFactory<MainContext> Factory;

        public PayeeAccountManager(IDbContextFactory<MainContext> factory) => Factory = factory;





        public IEnumerable<PayeeAccount> GetPayeeAccounts()
        {
            using var context = Factory.CreateDbContext();
            return context.PayeeAccounts.Include(pa => pa.Payee).ToList();
        }




        public void SavePayeeAccount(PayeeAccount payeeAccount)
        {
            payeeAccount.Validate();
            using MainContext context = Factory.CreateDbContext();
            if (context.PayeeAccounts.Any(c => c.Id == payeeAccount.Id))
                context.Update(payeeAccount);
            else
                context.Add(payeeAccount);
            context.SaveChanges();
        }

    }
}
