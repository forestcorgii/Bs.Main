using Bs.Common;
using Bs.Main.Modules.VoucherModule.Commands;
using Bs.Main.Modules.VoucherModule.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bs.Main.Modules.VoucherModule.ViewModels
{
    public class VoucherDetailVm : ViewModelBase
    {
        public Voucher Voucher { get; set; }

        public ICommand NavigateToListing { get; }
        public ICommand JournalDetail { get; }

        public VoucherDetailVm(NavigationService<VoucherDetailVm> voucherListingNavigation)
        {
            NavigateToListing = new NavigateCommand<VoucherDetailVm>(voucherListingNavigation);
            JournalDetail = new JournalEntryDetail(this);
        }



    }
}
