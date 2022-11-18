using Bs.Common;
using Bs.Main.Messages;
using Bs.Main.Modules.MasterlistModule.Commands.Generic;
using Bs.Main.Modules.MasterlistModule.Models;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using CommunityToolkit.Mvvm.Messaging;
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
        private CompanyAccount _selectedCompanyAccount = new();
        public CompanyAccount SelectedCompanyAccount { get => _selectedCompanyAccount; set => SetProperty(ref _selectedCompanyAccount, value); }


        private ObservableCollection<CompanyAccount> _companyAccounts = new();
        public ObservableCollection<CompanyAccount> CompanyAccounts { get => _companyAccounts; set => SetProperty(ref _companyAccounts, value); }

        private IEnumerable<string> _companyIds;
        public IEnumerable<string> CompanyIds { get => _companyIds; set => SetProperty(ref _companyIds, value); }



        public ICommand Listing { get; }

        public ICommand Save { get; }
        public ICommand Delete { get; }

        public CompanyAccountListingVm(CompanyAccounts companyAccounts)
        {

            Listing = new Listing(this, companyAccounts);
            Listing.Execute(null);

            Save = new Save(this, companyAccounts);
            Delete = new Delete(this, companyAccounts);


            OnReloadRequest += (s, e) =>
            {
                Listing.Execute(null);
                SelectedCompanyAccount = new();
            };
            CollectionChanged += (s, e) => CompanyAccounts = new ObservableCollection<CompanyAccount>(e.Select(o => (CompanyAccount)o));


            var companiesMessage = WeakReferenceMessenger.Default.Send<CurrentCompanyCollection>();
            if (companiesMessage.HasReceivedResponse)
                CompanyIds = companiesMessage.Response.Select(c => c.Id);
            IsActive = true;

        }


        protected override void OnActivated()
        {
            Messenger.Register<CompanyAccountListingVm, CompanyCollectionChanged>(this, (r, m) => r.CompanyIds = m.Value.Select(c => c.Id));
        }
    }
}
