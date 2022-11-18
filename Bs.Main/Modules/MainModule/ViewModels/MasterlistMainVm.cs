using Bs.Common;
using Bs.Main.Messages;
using Bs.Main.Modules.MainModule.Commands;
using Bs.Main.Modules.MasterlistModule.Models;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using Bs.Main.Modules.MasterlistModule.ViewModels;
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
    public class MasterlistMainVm : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;


        public ICommand CompanyAccountListing { get; }
        public ICommand CompanyListing { get; }
        public ICommand PayeeListing { get; }
        public ICommand PayeeAccountListing { get; }
        public ICommand JournalAccountListing { get; }

        public ICommand MasterlistListing { get; }


        public MasterlistMainVm(NavigationStore navigationStore,
            Companies companies,
            CompanyAccounts companyAccounts,
            Payees payees,
            PayeeAccounts payeeAccounts,
            JournalAccounts journalAccounts,
            NavigationService<CompanyListingVm> companyListing,
            NavigationService<CompanyAccountListingVm> companyAccountListing,
            NavigationService<PayeeListingVm> payeeListing,
            NavigationService<PayeeAccountListingVm> payeeAccountListing,
            NavigationService<JournalAccountListingVm> journalAccountListing)
        {

            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;


            CompanyListing = new NavigateCommand<CompanyListingVm>(companyListing);

            CompanyAccountListing = new NavigateCommand<CompanyAccountListingVm>(companyAccountListing);

            PayeeListing = new NavigateCommand<PayeeListingVm>(payeeListing);

            PayeeAccountListing = new NavigateCommand<PayeeAccountListingVm>(payeeAccountListing);

            JournalAccountListing = new NavigateCommand<JournalAccountListingVm>(journalAccountListing);

            IsActive = true;

            MasterlistListing = new MasterlistListing(this, companies, companyAccounts, payees, payeeAccounts, journalAccounts);
            MasterlistListing.Execute(null);

            OnReloadRequest += (s, e) => { MasterlistListing.Execute(null); };
        }

        private IEnumerable<Company> _companies;
        public IEnumerable<Company> Companies
        {
            get => _companies;
            set
            {
                SetProperty(ref _companies, value);
                Messenger.Send(new CompanyCollectionChanged(_companies));
            }
        }

        private IEnumerable<Payee> _payees;
        public IEnumerable<Payee> Payees
        {
            get => _payees;
            set
            {
                SetProperty(ref _payees, value);
                Messenger.Send(new PayeeCollectionChanged(_payees));
            }
        }


        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
            Reload();
        }
    }
}
