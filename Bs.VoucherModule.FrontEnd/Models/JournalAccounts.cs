using Bs.VoucherModule.Domain.ServiceLayer.EfCore;
using Bs.VoucherModule.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.VoucherModule.FrontEnd.Models
{
    public class JournalAccounts
    {
        private JournalAccountProvider Provider;

        public JournalAccounts(JournalAccountProvider provider) => Provider = provider;

        public IEnumerable<JournalAccountView> GetJournalAccounts() => Provider.GetJournalAccounts();
    }
}
