using Bs.Common;
using Bs.Main.Messages;
using Bs.Main.Modules.MasterlistModule.Models;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using Bs.Main.Modules.VoucherModule.ViewModels;
using Bs.Vouchers.FrontEnd.Commands;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bs.Vouchers.FrontEnd.ViewModels
{
    public class MainVm : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ObservableObject CurrentViewModel => _navigationStore.CurrentViewModel;


        public ICommand SelectCompany { get; }

        public ICommand VoucherMainListing { get; }
        public ICommand PayeeAccountListing { get; }

        public ICommand VoucherListing { get; }
        public ICommand CompanyListing { get; }
        public ICommand PayeeListing { get; }
        public ICommand VoucherDetail { get; }

        public ICommand ReloadFilters { get; }




        public MainVm(NavigationStore navigationStore, Companies companies, PayeeAccounts payeeAccounts, JournalAccounts journalAccounts,
            NavigationService<VoucherListingVm> voucherListing,
            NavigationService<VoucherDetailVm> voucherDetail
            )
        {
            
            SelectCompany = new RelayCommand<Company>((c) => SelectedCompany = c);

            VoucherMainListing = new VoucherMainListing(this, companies, journalAccounts);
            VoucherMainListing.Execute(null);

            PayeeAccountListing = new PayeeAccountListing(this, payeeAccounts);
            PayeeAccountListing.Execute(null);

            ReloadFilters = new RelayCommand(() => VoucherMainListing.Execute(null));

            IsActive = true;


            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            VoucherListing = new NavigateCommand<VoucherListingVm>(voucherListing);
            VoucherListing.Execute(null);

            VoucherDetail = new NavigateCommand<VoucherDetailVm>(voucherDetail);
        }

        #region Properties
        private string _payeeAccountSearchInput;
        public string PayeeAccountSearchInput
        {
            get => _payeeAccountSearchInput;
            set
            {
                SetProperty(ref _payeeAccountSearchInput, value);
                PayeeAccountListing.Execute(value);
            }
        }

        private IEnumerable<Company> _companies;
        public IEnumerable<Company> Companies
        {
            get => _companies;
            set
            {
                SetProperty(ref _companies, value);
                Messenger.Send(new CompanyCollectionChanged(value));
            }
        }

        private IEnumerable<JournalAccount> _journalAccounts;
        public IEnumerable<JournalAccount> JournalAccounts
        {
            get => _journalAccounts;
            set
            {
                SetProperty(ref _journalAccounts, value);
                Messenger.Send(new JournalAccountCollectionChanged(value));
            }
        }

        private IEnumerable<CompanyAccount> _companyAccounts;
        public IEnumerable<CompanyAccount> CompanyAccounts
        {
            get => _companyAccounts;
            set
            {
                SetProperty(ref _companyAccounts, value);
                SelectedCompanyAccount = _companyAccounts.FirstOrDefault();
            }
        }

        private IEnumerable<PayeeAccount> _payeeAccounts;
        public IEnumerable<PayeeAccount> PayeeAccounts
        {
            get => _payeeAccounts;
            set
            {
                SetProperty(ref _payeeAccounts, value);
                Messenger.Send(new PayeeAccountCollectionChanged(_payeeAccounts));
            }
        }

        private Company _selectedCompany;
        public Company SelectedCompany
        {
            get => _selectedCompany;
            set
            {
                SetProperty(ref _selectedCompany, value);
                if (_selectedCompany is not null)
                {
                    CompanyAccounts = _selectedCompany.CompanyAccounts;
                    Messenger.Send(new SelectedCompanyChanged(_selectedCompany));
                }
            }
        }

        private CompanyAccount _selectedCompanyAccount;
        public CompanyAccount SelectedCompanyAccount
        {
            get => _selectedCompanyAccount;
            set
            {
                SetProperty(ref _selectedCompanyAccount, value);
                if (_selectedCompanyAccount is not null)
                    Messenger.Send(new SelectedCompanyAccountChanged(_selectedCompanyAccount));
                else Messenger.Send(new SelectedCompanyAccountChanged(new()));
            }
        }

        private PayeeAccount _selectedPayeeAccount;
        public PayeeAccount SelectedPayeeAccount
        {
            get => _selectedPayeeAccount; set
            {
                SetProperty(ref _selectedPayeeAccount, value);
                if (_selectedPayeeAccount is not null)
                    Messenger.Send(new SelectedPayeeAccountChanged(_selectedPayeeAccount));
            }
        }
        #endregion

        protected override void OnActivated()
        {
            Messenger.Register<MainVm, CurrentCompany>(this, (r, m) => m.Reply(r.SelectedCompany));
            Messenger.Register<MainVm, CurrentCompanyAccount>(this, (r, m) => m.Reply(r.SelectedCompanyAccount));
            Messenger.Register<MainVm, CurrentPayeeAccount>(this, (r, m) => m.Reply(r.SelectedPayeeAccount));
            Messenger.Register<MainVm, CurrentJournalAccountCollection>(this, (r, m) => m.Reply(r.JournalAccounts));

        }


        private void OnCurrentViewModelChanged() =>
            OnPropertyChanged(nameof(CurrentViewModel));
    }
}
