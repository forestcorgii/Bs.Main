using Bs.Common.Models;
using Bs.Main.Modules.MasterlistModule.ServiceLayer.EfCore;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.MasterlistModule.Models
{
    public class JournalAccounts : IGenericModel
    {
        private JournalAccountManager Manager;

        public JournalAccounts(JournalAccountManager provider) => Manager = provider;

        public IEnumerable<JournalAccount> GetJournalAccounts() => Manager.GetJournalAccounts();
        public void Save(JournalAccount journalAccount) => Manager.SaveJournalAccount(journalAccount);
        public void Delete(JournalAccount journalAccount) => Manager.SaveJournalAccount(journalAccount);

        public IEnumerable<object> Get() => Manager.GetJournalAccounts();

        public void Save(object item)
        {
            if (item is JournalAccount payee)
                Manager.SaveJournalAccount(payee);
        }
        public void Delete(object item)
        {
            if (item is JournalAccount payee)
                Manager.RemoveJournalAccount(payee);
        }
    }
}
