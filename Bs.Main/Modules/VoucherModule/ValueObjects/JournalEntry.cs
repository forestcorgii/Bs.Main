using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.VoucherModule.ValueObjects
{
    public  class JournalEntry
    {
        public int Id { get; set; }

        public Guid VoucherId { get; set; }

        public string JournalAccountName { get; set; }

        public double Amount { get; set; }

        public double WithholdingTaxRate { get; set; }

        public double TaxAmount { get => Amount * WithholdingTaxRate; }
        public double NetAmount { get => Amount - TaxAmount; }

        public Dictionary<string, string> Particulars { get; set; }
    }
}
