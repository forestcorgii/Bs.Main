using Bs.Common;
using Bs.Common.Commands.Generic;
using Bs.Main.Messages;
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
    public class CompanyListingVm : ViewModelBase
    {

        private Company _selectedCompany;
        public Company SelectedCompany { get => _selectedCompany; set => SetProperty(ref _selectedCompany, value); }


        private ObservableCollection<Company> companies = new();
        public ObservableCollection<Company> Companies
        {
            get => companies; 
            set
            {
                SetProperty(ref companies, value);
                Messenger.Send(new CompanyCollectionChanged(companies));
            }
        }


        public ICommand Listing { get; }

        public ICommand Save { get; }
        public ICommand Delete { get; }

        public CompanyListingVm(Companies companies)
        {
            SelectedCompany = new();

            Listing = new Listing(this, companies);
            Listing.Execute(null);

            Save = new Save(this, companies);
            Delete = new Delete(this, companies);


            OnReloadRequest += (s, e) =>
            {
                Listing.Execute(null);
                SelectedCompany = new();
            };

            CollectionChanged += (s, e) => Companies = new ObservableCollection<Company>(e.Select(o => (Company)o));
            IsActive = true;
        }


    }
}
