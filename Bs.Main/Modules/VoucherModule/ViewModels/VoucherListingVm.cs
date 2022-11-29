using Bs.Common;
using Bs.Main.Modules.VoucherModule.Entities;
using Bs.Main.Modules.VoucherModule.Commands;
using Bs.Main.Modules.VoucherModule.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Bs.Main.Modules.VoucherModule.Enums;
using CommunityToolkit.Mvvm.Input;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using CommunityToolkit.Mvvm.Messaging;
using Bs.Main.Messages;

namespace Bs.Main.Modules.VoucherModule.ViewModels
{
    public class VoucherListingVm : ViewModelBase
    {
        private PayeeAccount selectedPayeeAccount;
        public PayeeAccount SelectedPayeeAccount
        {
            get => selectedPayeeAccount;
            set
            {
                selectedPayeeAccount = value;
                Listing.Execute(null);
                //Reload();
            }
        }

        private ObservableCollection<Voucher> _vouchers;
        public ObservableCollection<Voucher> Vouchers { get => _vouchers; set => SetProperty(ref _vouchers, value); }

        public ObservableCollection<VoucherStatus> VoucherStatusOption
        {
            get => new ObservableCollection<VoucherStatus>(Enum.GetValues(typeof(VoucherStatus)).Cast<VoucherStatus>());
        }

        public ICommand Listing { get; }
        public ICommand Detail { get; }
        public ICommand CancelVoucher { get; }
        public ICommand Print { get; }

        public ICommand ReloadListing { get; }


        public VoucherListingVm(Vouchers vouchers, NavigationService<VoucherDetailVm> voucherDetailNavigation)
        {
            Vouchers = new ObservableCollection<Voucher>();
            Print = new PrintVoucher(this, vouchers);
            Listing = new Listing(this, vouchers);
            Detail = new NavigateCommand<VoucherDetailVm>(voucherDetailNavigation);

            LoadValues();

            OnReloadRequest += (s, e) => Listing.Execute(null);
            ReloadListing = new RelayCommand(() => Reload());
            CollectionChanged += (s, e) => Vouchers = new ObservableCollection<Voucher>(e.Select(o => (Voucher)o));

            IsActive = true;
        }
        private void LoadValues()
        {
            PayeeAccount payeeAccount = WeakReferenceMessenger.Default.Send<CurrentPayeeAccount>();
            if (payeeAccount is not null)
                SelectedPayeeAccount = payeeAccount;

            OnPropertyChanged(nameof(Voucher));
        }
        protected override void OnActivated()
        {
            Messenger.Register<VoucherListingVm, SelectedPayeeAccountChanged>(this, (r, m) => r.SelectedPayeeAccount = m.Value);
        }
    }
}
