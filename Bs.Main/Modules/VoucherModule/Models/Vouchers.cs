using Bs.Common.Models;
using Bs.Main.Modules.VoucherModule.Entities;
using Bs.Main.Modules.VoucherModule.ServiceLayer.EfCore;
using Bs.Main.Modules.VoucherModule.ServiceLayer.Files;
using System.Collections.Generic;

namespace Bs.Main.Modules.VoucherModule.Models
{
    public class Vouchers : IGenericModel
    {
        VoucherProvider Provider;
        VoucherManager Manager;
        VoucherPrinter Printer;

        public Vouchers(VoucherProvider provider, VoucherManager manager, VoucherPrinter printer)
        {
            Provider = provider;
            Manager = manager;
            Printer = printer;
        }

        public string GenerateVoucherNumber(string companyId) => Provider.GenerateVoucherNumber(companyId);

        public IEnumerable<object> Get() => Provider.GetVouchers();

        public void Save(object item)
        {
            if (item is Voucher voucher)
            {
                voucher.Payee = null;
                voucher.PayeeAccount = null;
                voucher.Company = null;
                Manager.SaveVoucher(voucher);
            }
        }


        public void Print(Voucher item) => Printer.Print(item);



        public void Delete(object item) => throw new System.NotImplementedException();
    }
}
