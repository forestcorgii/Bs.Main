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
    public class PayeeAccounts : IGenericModel
    {
        private PayeeAccountManager Manager;

        public PayeeAccounts(PayeeAccountManager manager) => Manager = manager;

        public IEnumerable<object> Get() => Manager.GetPayeeAccounts();

        public void Save(object item)
        {
            if (item is PayeeAccount payeeAccount)
            {
                if (payeeAccount.Payee is not null)
                {
                    payeeAccount.PayeeId = payeeAccount.Payee.Id;
                    payeeAccount.Payee = null;
                }
                Manager.SavePayeeAccount(payeeAccount);
            }
        }
        public void Delete(object item)
        {
            if (item is PayeeAccount payee)
                Manager.RemovePayeeAccount(payee);
        }
    }
}
