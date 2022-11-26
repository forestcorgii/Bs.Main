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
    public class PayeeListingVm : ViewModelBase
    {
        private Payee _selectedPayee = new();
        public Payee SelectedPayee { get => _selectedPayee; set => SetProperty(ref _selectedPayee, value); }

        private ObservableCollection<Payee> _payees;
        public ObservableCollection<Payee> Payees
        {
            get => _payees; 
            set
            { 
                Messenger.Send(new PayeeCollectionChanged(value));
                SetProperty(ref _payees, value);
            }
        }

        public ICommand Save { get; }
        public ICommand Delete { get; }

        public ICommand Listing { get; }


        public PayeeListingVm(Payees payees)
        {
            Listing = new Listing(this, payees);
            Listing.Execute(null);

            Save = new Save(this, payees);
            Delete = new Delete(this, payees);


            OnReloadRequest += (s, e) =>
            {
                SelectedPayee = new();
                Listing.Execute(null);
            };

            CollectionChanged += (s, e) => Payees = new ObservableCollection<Payee>(e.Select(o => (Payee)o));
            IsActive = true;
        }

    }
}
