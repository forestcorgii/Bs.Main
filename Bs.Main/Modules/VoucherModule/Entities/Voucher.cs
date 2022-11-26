using Bs.Main.Modules.MasterlistModule.ValueObjects;
using Bs.Main.Modules.VoucherModule.Enums;
using Bs.Main.Modules.VoucherModule.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.VoucherModule.Entities
{
    public class Voucher
    {
        public Guid Id { get; set; }

        public Guid PayeeId { get; set; }
        public Payee Payee { get; set; }

        public int PayeeAccountId { get; set; }
        public PayeeAccount PayeeAccount { get; set; }

        public string CompanyId { get; set; }
        public Company Company { get; set; }

        public string CompanyAccountCode { get; set; }


        public string VoucherNumber { get; set; }
        public DateTime EntryDate { get; set; }

        public ObservableCollection<JournalEntry> JournalEntries { get; set; }

        public string Remarks { get; set; }

        public VoucherStatus Status { get; set; }


        public bool UseOwnerName { get; set; }// use owner name as payee name
        public string PayeeNameToUse { get => UseOwnerName ? Payee.OwnerName : Payee.PayeeName; }


        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }



        public Voucher()
        {
            Id = Guid.NewGuid();
            EntryDate = DateTime.Now;
            JournalEntries = new();
        }


        public override string ToString() => VoucherNumber;
    }
}
