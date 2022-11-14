using Bs.VoucherModule.Domain.Entities;
using Bs.VoucherModule.FrontEnd.Models;
using Bs.VoucherModule.FrontEnd.ViewModels;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.VoucherModule.FrontEnd.Commands
{
    public class Listing : IRelayCommand
    {
        VoucherListingVm ListingVm;
        Vouchers Vouchers;
        public Listing(VoucherListingVm listingVm, Vouchers vouchers)
        {
            ListingVm = listingVm;
            ListingVm.CanExecuteChanged += ListingVm_CanExecuteChanged;
            Vouchers = vouchers;
        }


        public async void Execute(object? parameter)
        {
            IEnumerable<Voucher> voucher = new List<Voucher>();
            await Task.Run(() =>
            {
                voucher = Vouchers.GetVouchers();
            });
        }



        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter) => ListingVm.Executable;
        private void ListingVm_CanExecuteChanged(object? sender, bool e) => NotifyCanExecuteChanged();
        public void NotifyCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, new EventArgs());

    }
}
