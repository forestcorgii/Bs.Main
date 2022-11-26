using Bs.Common;
using Bs.Common.Commands;
using Bs.Main.Modules.VoucherModule.Entities;
using Bs.Main.Modules.VoucherModule.Models;
using Bs.Main.Modules.VoucherModule.ValueObjects;
using Bs.Main.Modules.VoucherModule.ViewModels;
using Bs.Main.Modules.VoucherModule.Views;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.VoucherModule.Commands
{
    public class JournalEntryDetail : CommandBase
    {
        VoucherDetailVm VoucherDetailVm;
        public JournalEntryDetail(VoucherDetailVm voucherDetailVm) : base(voucherDetailVm)
        {
            VoucherDetailVm = voucherDetailVm;
        }


        public override void Execute(object parameter)
        {
            JournalEntryDetailVm journalDetailVm = new(VoucherDetailVm);
            
            if (parameter is JournalEntry entry)
                journalDetailVm.JournalEntry = entry;
            
            var view = new JournalDetailView() { DataContext = journalDetailVm };

            if (view.ShowDialog() is bool res && res && parameter is null)
            {
                VoucherDetailVm.Voucher.JournalEntries.Add(journalDetailVm.JournalEntry);
                VoucherDetailVm.ForcePropertyChange();
            }
        }



    }
}
