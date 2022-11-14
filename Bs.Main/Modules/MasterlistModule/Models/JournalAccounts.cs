using Bs.Main.Modules.MasterlistModule.ServiceLayer.EfCore;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.MasterlistModule.Models
{
    public class JournalAccounts
    {
        private JournalAccountManager Manager;

        public JournalAccounts(JournalAccountManager provider) => Manager = provider;

        public IEnumerable<JournalAccount> GetJournalAccounts() => Manager.GetJournalAccounts();
    }
}
