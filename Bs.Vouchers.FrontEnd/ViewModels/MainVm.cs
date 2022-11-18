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

        public ICommand VoucherListing { get; }
        public ICommand CompanyListing { get; }
        public ICommand PayeeListing { get; }
        public ICommand VoucherDetail { get; }




        public MainVm(NavigationStore navigationStore, Companies companies, PayeeAccounts payeeAccounts,
            NavigationService<VoucherListingVm> voucherListing,
            NavigationService<VoucherDetailVm> voucherDetail
            )
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;


            VoucherListing = new NavigateCommand<VoucherListingVm>(voucherListing);
            VoucherListing.Execute(null);

            VoucherDetail = new NavigateCommand<VoucherDetailVm>(voucherDetail);


            SelectCompany = new RelayCommand<Company>(OnSelectCompany);

            VoucherMainListing = new VoucherMainListing(this, companies, payeeAccounts);
            VoucherMainListing.Execute(null);
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


        private IEnumerable<CompanyAccount> _companyAccounts;
        public IEnumerable<CompanyAccount> CompanyAccounts { get => _companyAccounts; set => SetProperty(ref _companyAccounts, value); }


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
                CompanyAccounts = _selectedCompany.CompanyAccounts;
            }
        }

        private PayeeAccount _selectedPayeeAccount;

        public PayeeAccount SelectedPayeeAccount { get => _selectedPayeeAccount; set => SetProperty(ref _selectedPayeeAccount, value); }

        private void OnSelectCompany(Company selectedCompanyId) => SelectedCompany = selectedCompanyId;



        private void OnCurrentViewModelChanged() =>
            OnPropertyChanged(nameof(CurrentViewModel));
    }
}
