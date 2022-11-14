using Bs.Main.Modules.MasterlistModule.ServiceLayer.EfCore;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.MasterlistModule.Models
{
    public class Companies
    {
        private CompanyManager CompanyManager;

        public Companies(CompanyManager companyProvider) => CompanyManager = companyProvider;

        public IEnumerable<Company> GetCompanies() => CompanyManager.GetCompanies();

    }
}
