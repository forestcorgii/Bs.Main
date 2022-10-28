using Bs.VoucherModule.Domain.ServiceLayer.EfCore;
using Bs.VoucherModule.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.VoucherModule.FrontEnd.Models
{
    public class PayeeAccounts
    {
        private PayeeAccountProvider Provider;

        public PayeeAccounts(PayeeAccountProvider provider) => Provider = provider;


        public IEnumerable<PayeeAccountView> GetPayeeAccounts() => Provider.GetPayeeAccounts();
    }
}
