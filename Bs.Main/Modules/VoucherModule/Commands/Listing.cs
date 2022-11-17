using Bs.Common;
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
    public class Listing : CommandBase
    {
        VoucherListingVm ListingVm;
        Vouchers Vouchers;

        public Listing(VoucherListingVm listingVm, Vouchers vouchers) : base(listingVm)
        {
            ListingVm = listingVm;
            Vouchers = vouchers;
        }


        public override async void Execute(object parameter)
        {
            IEnumerable<Voucher> voucher = new List<Voucher>();
            await Task.Run(() =>
            {
                voucher = Vouchers.GetVouchers();
            });
        }
         
    }
}
