using Bs.MasterlistModule.Domain.ServiceLayer.EfCore;
using Bs.MasterlistModule.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.MasterlistModule.FrontEnd.Models
{
    public class Payees
    {
        private PayeeManager Manager;

        public Payees(PayeeManager manager) => Manager = manager;


        public IEnumerable<Payee> GetPayeeAccounts() => Manager.GetPayees();
    }
}
