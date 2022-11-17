using Bs.Common;
using Bs.Main.Modules.MasterlistModule.Commands.Generic;
using Bs.Main.Modules.MasterlistModule.Models;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bs.Main.Modules.MasterlistModule.ViewModels
{
    public class CompanyAccountListingVm : ViewModelBase
    {
        private CompanyAccount _selectedCompanyAccount;
        public CompanyAccount SelectedCompanyAccount { get => _selectedCompanyAccount; set => SetProperty(ref _selectedCompanyAccount, value); }


        private ObservableCollection<CompanyAccount> companyAccounts = new();
        public ObservableCollection<CompanyAccount> CompanyAccounts { get => companyAccounts; set => SetProperty(ref companyAccounts, value); }


        public ICommand Listing { get; }

        public ICommand Save { get; }
        public ICommand Delete { get; }

        public CompanyAccountListingVm(CompanyAccounts companyAccounts)
        {
            Listing = new Listing(this, companyAccounts);
            Listing.Execute(null);

            Save = new Save(this, companyAccounts);
            Delete = new Delete(this, companyAccounts);


            OnReloadRequest += (s, e) => Listing.Execute(null);

            CollectionChanged += (s, e) => CompanyAccounts = new ObservableCollection<CompanyAccount>(e.Select(o => (CompanyAccount)o));
        }

    }
}
