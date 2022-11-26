using Bs.Common;
using Bs.Common.Commands.Generic;
using Bs.Main.Messages;
using Bs.Main.Modules.MasterlistModule.Models;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using CommunityToolkit.Mvvm.Input;
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
    public class PayeeAccountListingVm : ViewModelBase
    {
        #region PROPERTIES
        private PayeeAccount _selectedPayeeAccount = new();
        public PayeeAccount SelectedPayeeAccount { get => _selectedPayeeAccount; set => SetProperty(ref _selectedPayeeAccount, value); }

        private ObservableCollection<PayeeAccount> _payeeAccounts;
        public ObservableCollection<PayeeAccount> PayeeAccounts { get => _payeeAccounts; set => SetProperty(ref _payeeAccounts, value); }

        private IEnumerable<Payee> _payeeIds;
        public IEnumerable<Payee> PayeeIds { get => _payeeIds; set => SetProperty(ref _payeeIds, value); }
        #endregion

        #region COMMANDS
        public ICommand Save { get; }
        public ICommand Delete { get; }

        public ICommand Listing { get; }

        public ICommand AddParticularItem { get; }
        public ICommand RemoveParticularItem { get; }
        #endregion

        #region LAMBDAS
        private void HandleLambdas()
        {
            OnReloadRequest += (s, e) =>
            {
                SelectedPayeeAccount = new();
                Listing.Execute(null);
            };

            CollectionChanged += (s, e) => PayeeAccounts = new ObservableCollection<PayeeAccount>(e.Select(o => (PayeeAccount)o));
        }
        #endregion

        public PayeeAccountListingVm(PayeeAccounts payeeAccounts)
        {
            Listing = new Listing(this, payeeAccounts);
            Listing.Execute(null);

            AddParticularItem = new RelayCommand(() => SelectedPayeeAccount.DefaultParticulars.Add(new("", "")));
            RemoveParticularItem = new RelayCommand<ParticularsKeyValue>((p) => SelectedPayeeAccount.DefaultParticulars.Remove(p));

            Save = new Save(this, payeeAccounts);
            Delete = new Delete(this, payeeAccounts);

            HandleLambdas();

            IsActive = true;

            PayeeIds = WeakReferenceMessenger.Default.Send<CurrentPayeeCollection>().Response;
        }



        protected override void OnActivated()
        {
            Messenger.Register<PayeeAccountListingVm, PayeeCollectionChanged>(this, (r, m) => r.PayeeIds = m.Value);
        }

    }
}
