using Bs.MasterlistModule.Domain.ServiceLayer.EfCore;
using Bs.MasterlistModule.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.MasterlistModule.FrontEnd.Models
{
    public class PayeeAccounts
    {
        private PayeeAccountManager Manager;

        public PayeeAccounts(PayeeAccountManager manager) => Manager = manager;


        public IEnumerable<PayeeAccount> GetPayeeAccounts() => Manager.GetPayeeAccounts();
    }
}
