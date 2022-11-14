using Bs.VoucherModule.Domain.Entities;
using Bs.VoucherModule.Domain.ServiceLayer.EfCore;
using System.Collections.Generic;

namespace Bs.VoucherModule.FrontEnd.Models
{
    public class Vouchers
    {
        VoucherProvider Provider;

        public Vouchers(VoucherProvider provider)
        {
            Provider = provider;
        }



        public IEnumerable<Voucher> GetVouchers() => Provider.GetVouchers();
    }
}
