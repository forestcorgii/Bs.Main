using Bs.VoucherModule.FrontEnd.ViewModels;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.VoucherModule.FrontEnd.Commands
{
    public class Detail : IRelayCommand
    {
        VoucherListingVm ListingVm;

        public Detail(VoucherListingVm listingVm)
        {
            ListingVm = listingVm;
            ListingVm.CanExecuteChanged += ListingVm_CanExecuteChanged;
        }

        public void Execute(object? parameter)
        {
            //VoucherDetailVm detailVm = new();
        }
         


        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter) => ListingVm.Executable;
        private void ListingVm_CanExecuteChanged(object? sender, bool e) => NotifyCanExecuteChanged();
        public void NotifyCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, new EventArgs());

    }
}
