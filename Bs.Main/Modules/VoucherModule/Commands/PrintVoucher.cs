using Bs.Common;
using Bs.Common.Commands;
using Bs.Main.Modules.VoucherModule.Entities;
using Bs.Main.Modules.VoucherModule.Models;
using Bs.Main.Modules.VoucherModule.ViewModels;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.VoucherModule.Commands
{
    public class PrintVoucher : CommandBase
    {
        private Vouchers Vouchers;
        public PrintVoucher(VoucherListingVm listingVm, Vouchers vouchers) : base(listingVm)
        {
            Vouchers = vouchers;
        }

        public async override void Execute(object parameter)
        {
            if (parameter is Voucher voucher)
                await Task.Run(() => Vouchers.Print(voucher));
        }

    }
}
