using Bs.Main.Modules.MasterlistModule.ServiceLayer.EfCore;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.MasterlistModule.Models
{
    public class PayeeAccounts
    {
        private PayeeAccountManager Manager;

        public PayeeAccounts(PayeeAccountManager manager) => Manager = manager;


        public IEnumerable<PayeeAccount> GetPayeeAccounts() => Manager.GetPayeeAccounts();
        public void Save(PayeeAccount payeeAccount) => Manager.SavePayeeAccount(payeeAccount);
        public void Delete(PayeeAccount payeeAccount) => Manager.SavePayeeAccount(payeeAccount);
    }
}
