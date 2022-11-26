using Bs.Common;
using Bs.Main.Messages;
using Bs.Main.Modules.VoucherModule.Commands;
using Bs.Main.Modules.VoucherModule.Entities;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using Bs.Main.Modules.VoucherModule.Models;
using Bs.Common.Commands.Generic;
using CommunityToolkit.Mvvm.Input;
using Bs.Main.Modules.VoucherModule.ValueObjects;

namespace Bs.Main.Modules.VoucherModule.ViewModels
{
    public class VoucherDetailVm : ViewModelBase
    {
        private Voucher _voucher = new();
        public Voucher Voucher { get => _voucher; set => SetProperty(ref _voucher, value); }


        public ICommand NavigateToListing { get; }

        public ICommand JournalDetail { get; }
        public ICommand RemoveJournal { get; }

        public ICommand Save { get; }
        public ICommand SaveVoucher { get; }

        private Vouchers VoucherModel;

        public VoucherDetailVm(Vouchers vouchers,
            NavigationService<VoucherListingVm> voucherListingNavigation)
        {
            VoucherModel = vouchers;
            LoadValues();

            Voucher.VoucherNumber = vouchers.GenerateVoucherNumber(Voucher.CompanyId);
            OnPropertyChanged(nameof(Voucher));

            NavigateToListing = new NavigateCommand<VoucherListingVm>(voucherListingNavigation);
            JournalDetail = new JournalEntryDetail(this);

            RemoveJournal = new RelayCommand<JournalEntry>((j) => Voucher.JournalEntries.Remove(j));
            
            SaveVoucher = new Save(this, vouchers);
            Save = new RelayCommand<object>((v) => {
                SaveVoucher.Execute(v);
                NavigateToListing.Execute(null);
            });
            IsActive = true;
        }



        private void LoadValues()
        {
            PayeeAccount payeeAccount = WeakReferenceMessenger.Default.Send<CurrentPayeeAccount>();
            if (payeeAccount is not null)
            {
                Voucher.PayeeAccount = payeeAccount;
                Voucher.PayeeAccountId = payeeAccount.Id;
                Voucher.Payee = payeeAccount.Payee;
                Voucher.PayeeId = payeeAccount.PayeeId;
            }

            Company company = WeakReferenceMessenger.Default.Send<CurrentCompany>();
            if (company is not null)
            {
                Voucher.Company = company;
                Voucher.CompanyId = company.Id;
            }

            CompanyAccount companyAccount = WeakReferenceMessenger.Default.Send<CurrentCompanyAccount>();
            if (companyAccount is not null)
                Voucher.CompanyAccountCode = companyAccount.Code;

            OnPropertyChanged(nameof(Voucher));
        }

        protected override void OnActivated()
        {
            Messenger.Register<VoucherDetailVm, SelectedPayeeAccountChanged>(this, (r, m) =>
            {
                r.Voucher.Payee = m.Value.Payee;
                r.Voucher.PayeeId = m.Value.PayeeId;
                r.Voucher.PayeeAccount = m.Value;
                r.Voucher.PayeeAccountId = m.Value.Id;
                OnPropertyChanged(nameof(Voucher));
            });
            Messenger.Register<VoucherDetailVm, SelectedCompanyChanged>(this, (r, m) =>
            {
                r.Voucher.CompanyId = m.Value.Id;
                r.Voucher.Company = m.Value;
                r.Voucher.VoucherNumber = VoucherModel.GenerateVoucherNumber(Voucher.CompanyId);

                OnPropertyChanged(nameof(Voucher));
            });
            Messenger.Register<VoucherDetailVm, SelectedCompanyAccountChanged>(this, (r, m) =>
            {
                r.Voucher.CompanyAccountCode = m.Value?.Code;
                OnPropertyChanged(nameof(Voucher));
            });
        }

        public void ForcePropertyChange() =>
                OnPropertyChanged();
    }
}
