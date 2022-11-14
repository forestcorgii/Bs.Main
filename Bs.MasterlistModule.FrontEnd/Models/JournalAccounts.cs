using Bs.MasterlistModule.Domain.ServiceLayer.EfCore;
using Bs.MasterlistModule.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.MasterlistModule.FrontEnd.Models
{
    public class JournalAccounts
    {
        private JournalAccountManager Manager;

        public JournalAccounts(JournalAccountManager provider) => Manager = provider;

        public IEnumerable<JournalAccount> GetJournalAccounts() => Manager.GetJournalAccounts();
    }
}
