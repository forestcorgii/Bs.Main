using Bs.Common;
using Bs.VoucherModule.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bs.VoucherModule.FrontEnd.ViewModels
{
    public class VoucherDetailVm : ViewModelBase
    {
        public Voucher Voucher { get; set; }

        public ICommand NavigateToListing { get; }

        public VoucherDetailVm(NavigationService<VoucherDetailVm> voucherListingNavigation)
        {
            NavigateToListing = new NavigateCommand<VoucherDetailVm>(voucherListingNavigation);
        }




    }
}
