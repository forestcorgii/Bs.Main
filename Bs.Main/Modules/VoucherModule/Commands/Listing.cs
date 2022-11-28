using Bs.Common;
using Bs.Common.Commands;
using Bs.Main.Modules.VoucherModule.Entities;
using Bs.Main.Modules.VoucherModule.Models;
using Bs.Main.Modules.VoucherModule.ViewModels;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.VoucherModule.Commands
{
    public class Listing : CommandBase
    {
        VoucherListingVm Vm;
        Vouchers Vouchers;

        public Listing(VoucherListingVm listingVm, Vouchers vouchers) : base(listingVm)
        {
            Vm = listingVm;
            Vouchers = vouchers;
        }


        public override async void Execute(object parameter)
        {
            IEnumerable<Voucher> vouchers = new List<Voucher>();
            await Task.Run(() =>
            {
                vouchers = Vouchers.Get().Select(v => (Voucher)v);
                vouchers= vouchers.Where(v => v.PayeeAccountId == Vm.SelectedPayeeAccount.Id);
            });



            Vm.Vouchers = new ObservableCollection<Voucher>(vouchers);
        }

    }
}
