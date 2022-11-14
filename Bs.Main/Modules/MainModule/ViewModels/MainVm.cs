using Bs.Common;
using Bs.Main.Modules.VoucherModule.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bs.Main.Modules.MainModule.ViewModels
{
    public class MainVm : ObservableObject
    {
        private readonly NavigationStore _navigationStore;
        public ObservableObject CurrentViewModel => _navigationStore.CurrentViewModel;

        public ICommand VoucherListingNavigation { get; }

        public MainVm(NavigationStore navigationStore, NavigationService<VoucherListingVm> voucherListingNavigation)
        {
            VoucherListingNavigation = new NavigateCommand<VoucherListingVm>(voucherListingNavigation);
            VoucherListingNavigation.Execute(null);

            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }


        private void OnCurrentViewModelChanged() =>
            OnPropertyChanged(nameof(CurrentViewModel));
    }
}
