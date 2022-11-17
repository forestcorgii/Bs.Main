using Bs.Main.Modules.MasterlistModule.ServiceLayer.EfCore;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.MasterlistModule.Models
{
    public class CompanyAccounts : IGenericModel
    {
        private CompanyAccountManager Manager;

        public CompanyAccounts(CompanyAccountManager manager) => Manager = manager;

        public IEnumerable<object> Get() => Manager.GetCompanyAccounts();

        public void Delete(object item)
        {
            if (item is CompanyAccount companyAccount)
                Manager.SaveCompanyAccount(companyAccount);
            else throw new Exception("Object Mismatch");
        }

        public void Save(object item)
        {
            if (item is CompanyAccount companyAccount)
                Manager.SaveCompanyAccount(companyAccount);
            else throw new Exception("Object Mismatch");
        }
    }
}
