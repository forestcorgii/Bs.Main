using Bs.Main.Modules.VoucherModule.Entities;
using Bs.Main.Modules.VoucherModule.ServiceLayer.EfCore;
using System.Collections.Generic;

namespace Bs.Main.Modules.VoucherModule.Models
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
