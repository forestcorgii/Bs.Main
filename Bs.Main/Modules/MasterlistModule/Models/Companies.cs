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
    public class Companies : IGenericModel
    {
        private CompanyManager Manager;

        public Companies(CompanyManager companyProvider) => Manager = companyProvider;

        public IEnumerable<object> Get() => Manager.GetCompanies();
        
        public void Delete(object item)
        {
            if (item is Company company)
                Manager.RemoveCompany(company);
            else throw new Exception("Object Mismatch");
        }

        public void Save(object item)
        {
            if (item is Company company)
                Manager.SaveCompany(company);
            else throw new Exception("Object Mismatch");
        }
    }
}
