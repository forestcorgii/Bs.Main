using Bs.Common;
using Bs.Main.Messages;
using Bs.Main.Modules.MainModule.Commands;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using Bs.Main.Modules.VoucherModule.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bs.Main.Modules.MainModule.ViewModels
{
    public class MainVm : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ObservableObject CurrentViewModel => _navigationStore.CurrentViewModel;



        public IEnumerable<PayeeAccount> PayeeAccounts { get; set; }

        public ICommand SelectCompany { get; }

        public ICommand VoucherListing { get; }
        public ICommand CompanyListing { get; }
        public ICommand PayeeListing { get; }
        public ICommand VoucherDetail { get; }




        public MainVm(NavigationStore navigationStore,
            NavigationService<VoucherListingVm> voucherListing,
            NavigationService<VoucherDetailVm> voucherDetail
            )
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;


            VoucherListing = new NavigateCommand<VoucherListingVm>(voucherListing);
            VoucherListing.Execute(null);

            VoucherDetail = new NavigateCommand<VoucherDetailVm>(voucherDetail);


            SelectCompany = new RelayCommand<string>(OnSelectCompany);

            SelectedCompany = WeakReferenceMessenger.Default.Send<CurrentCompany>().Response.Id;

        }


        private List<Company> _companies;
        public List<Company> Companies
        {
            get => _companies; 
            set
            {
                Messenger.Send(new CompanyCollectionChanged(value));
                SetProperty(ref _companies, value);
            }
        }

        private string _selectedCompany;
        public string SelectedCompany { get => _selectedCompany; set => SetProperty(ref _selectedCompany, value); }

        private PayeeAccount _selectedPayeeAccount;

        public PayeeAccount SelectedPayeeAccount { get => _selectedPayeeAccount; set => SetProperty(ref _selectedPayeeAccount, value); }

        private void OnSelectCompany(string selectedCompanyId) => SelectedCompany = selectedCompanyId;


        private void OnCurrentViewModelChanged() =>
            OnPropertyChanged(nameof(CurrentViewModel));
    }
}
