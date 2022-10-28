using Bs.CheckApp.Domain.Enums;
using Bs.CheckApp.Domain.ValueObjects;
using System;

namespace Bs.CheckApp.Domain.Models
{
    public class Cheque
    {
        public string CheckNumber { get; set; }

        public int ChequeBookNumber { get; set; }
        //public ChequeBook ChequeBook { get; set; }

        public string VoucherNumber { get; set; }
        //public VoucherView Voucher { get; set; }

        public string PayeeLine1 { get; set; }
        public string PayeeLine2 { get; set; }
        public string Endorsement { get; set; }
        //public PayeeView Payee { get; set; }

        public double Amount { get; set; }

        public ChequeStatus Status { get; set; }

        public string Remarks { get; set; }

        public bool IsCrossed { get; set; }


        public override string ToString() => CheckNumber;
    }
}
