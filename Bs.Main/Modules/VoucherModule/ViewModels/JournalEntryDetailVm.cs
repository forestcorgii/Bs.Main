using Bs.Common;
using Bs.Main.Messages;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using Bs.Main.Modules.VoucherModule.Commands;
using Bs.Main.Modules.VoucherModule.Entities;
using Bs.Main.Modules.VoucherModule.ValueObjects;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bs.Main.Modules.VoucherModule.ViewModels
{
    public class JournalEntryDetailVm : ViewModelBase
    {
        private JournalEntry _journalEntry = new();
        public JournalEntry JournalEntry { get => _journalEntry; set => SetProperty(ref _journalEntry, value); }

        public IEnumerable<string> JournalAccounts { get; set; }

        public ICommand AddParticularItem { get; }
        public ICommand RemoveParticularItem { get; }

        public JournalEntryDetailVm(VoucherDetailVm voucherDetailVm)
        {

            JournalEntry.Particulars = voucherDetailVm.Voucher.PayeeAccount?.DefaultParticulars;

            JournalAccounts = WeakReferenceMessenger.Default.Send<CurrentJournalAccountCollection>().Response.Select(j => j.Name);

            AddParticularItem = new RelayCommand(() => JournalEntry.Particulars.Add(new("", "")));
            RemoveParticularItem = new RelayCommand<ParticularsKeyValue>((p) => JournalEntry.Particulars.Remove(p));
        }


    }
}
