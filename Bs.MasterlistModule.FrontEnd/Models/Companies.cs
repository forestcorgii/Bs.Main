using Bs.MasterlistModule.Domain.ServiceLayer.EfCore;
using Bs.MasterlistModule.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.MasterlistModule.FrontEnd.Models
{
    public class Companies
    {
        private CompanyManager CompanyManager;

        public Companies(CompanyManager companyProvider) => CompanyManager = companyProvider;

        public IEnumerable<Company> GetCompanies() => CompanyManager.GetCompanies();

    }
}
