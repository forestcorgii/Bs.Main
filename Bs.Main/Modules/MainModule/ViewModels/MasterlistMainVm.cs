using Bs.Common;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using Bs.Main.Modules.MasterlistModule.ViewModels;
using Bs.Main.Modules.VoucherModule.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bs.Main.Modules.MainModule.ViewModels
{
    public class MasterlistMainVm : ObservableObject
    {
        private readonly NavigationStore _navigationStore;
        public ObservableObject CurrentViewModel => _navigationStore.CurrentViewModel;


        public ICommand CompanyAccountListing { get; }
        public ICommand CompanyListing { get; }



        public MasterlistMainVm(NavigationStore navigationStore,
            NavigationService<CompanyListingVm> companyListing,
            NavigationService<CompanyAccountListingVm> companyAccountListing)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;



            CompanyListing = new NavigateCommand<CompanyListingVm>(companyListing);
            CompanyListing.Execute(null);

            CompanyAccountListing = new NavigateCommand<CompanyAccountListingVm>(companyAccountListing);

        }



        private void OnCurrentViewModelChanged() =>
            OnPropertyChanged(nameof(CurrentViewModel));
    }
}
