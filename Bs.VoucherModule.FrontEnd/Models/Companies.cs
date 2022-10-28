using Bs.VoucherModule.Domain.ServiceLayer.EfCore;
using Bs.VoucherModule.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.VoucherModule.FrontEnd.Models
{
    public class Companies
    {
        private CompanyProvider CompanyProvider;

        public Companies(CompanyProvider companyProvider) => CompanyProvider = companyProvider;

        public IEnumerable<CompanyView> GetCompanies() => CompanyProvider.GetCompanies();

    }
}
