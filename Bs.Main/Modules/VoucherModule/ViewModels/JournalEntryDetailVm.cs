using Bs.Common;
using Bs.Main.Modules.VoucherModule.Commands;
using Bs.Main.Modules.VoucherModule.Entities;
using Bs.Main.Modules.VoucherModule.ValueObjects;
using System;
using System.Collections.Generic;
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

        public JournalEntryDetailVm(VoucherDetailVm voucherDetailVm)
        {
            JournalEntry.Particulars = new();
            JournalEntry.Particulars.Add("uid", "19823719273");
            JournalEntry.Particulars.Add("count", "10002");
            JournalEntry.Particulars.Add("something", "dadalala");
        }

    }
}
