using Bs.Main.Modules.MasterlistModule.ServiceLayer.EfCore;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.MasterlistModule.Models
{
    public class Payees : IGenericModel
    {
        private PayeeManager Manager;

        public Payees(PayeeManager manager) => Manager = manager;


        public IEnumerable<object> Get() => Manager.GetPayees();

        public void Save(object item)
        {
            if (item is Payee payee)
                Manager.SavePayee(payee);
        }
        public void Delete(object item)
        {
            if (item is Payee payee)
                Manager.RemovePayee(payee);
        }
    }
}
