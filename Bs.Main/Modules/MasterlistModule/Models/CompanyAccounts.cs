using Bs.Main.Modules.MasterlistModule.ServiceLayer.EfCore;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.MasterlistModule.Models
{
    public class CompanyAccounts
    {
        private CompanyAccountManager CompanyManager;

        public CompanyAccounts(CompanyAccountManager manager) => CompanyManager = manager;

        public IEnumerable<CompanyAccount> GetCompanies() => CompanyManager.GetCompanyAccounts();

    }
}
