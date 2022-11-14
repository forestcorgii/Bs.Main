using Bs.MasterlistModule.Domain.ServiceLayer.EfCore;
using Bs.MasterlistModule.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.MasterlistModule.FrontEnd.Models
{
    public class CompanyAccounts
    {
        private CompanyAccountManager CompanyManager;

        public CompanyAccounts(CompanyAccountManager manager) => CompanyManager = manager;

        public IEnumerable<CompanyAccount> GetCompanies() => CompanyManager.GetCompanyAccounts();

    }
}
