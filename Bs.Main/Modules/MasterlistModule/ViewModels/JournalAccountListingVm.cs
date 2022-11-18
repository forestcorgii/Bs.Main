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
    public class JournalAccountListingVm : ViewModelBase
    {
        private JournalAccount _selectedJournalAccount = new();
        public JournalAccount SelectedJournalAccount { get => _selectedJournalAccount; set => SetProperty(ref _selectedJournalAccount, value); }

        private ObservableCollection<JournalAccount> _journalAccounts;
        public ObservableCollection<JournalAccount> JournalAccounts { get => _journalAccounts; set => SetProperty(ref _journalAccounts, value); }

        public ICommand Save { get; }
        public ICommand Delete { get; }

        public ICommand Listing { get; }


        public JournalAccountListingVm(JournalAccounts journalAccounts)
        {
            Listing = new Listing(this, journalAccounts);
            Listing.Execute(null);

            Save = new Save(this, journalAccounts);
            Delete = new Delete(this, journalAccounts);


            OnReloadRequest += (s, e) =>
            {
                SelectedJournalAccount = new();
                Listing.Execute(null);
            };

            CollectionChanged += (s, e) => JournalAccounts = new ObservableCollection<JournalAccount>(e.Select(o => (JournalAccount)o));
            IsActive = true;
        }
    }
}
