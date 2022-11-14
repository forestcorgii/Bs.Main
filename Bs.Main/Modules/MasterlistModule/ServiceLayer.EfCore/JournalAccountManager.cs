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
    public class JournalAccountManager
    {
        private IDbContextFactory<MainContext> Factory;

        public JournalAccountManager(IDbContextFactory<MainContext> factory) => Factory = factory;



        public IEnumerable<JournalAccount> GetJournalAccounts()
        {
            using var context = Factory.CreateDbContext();
            return context.JournalAccounts.ToList();
        }


        public void SaveJournalAccount(JournalAccount journalAccount)
        {
            journalAccount.Validate();
            using MainContext context = Factory.CreateDbContext();
            if (context.JournalAccounts.Any(c => c.Id == journalAccount.Id))
                context.Update(journalAccount);
            else
                context.Add(journalAccount);
            context.SaveChanges();
        }


    }
}
