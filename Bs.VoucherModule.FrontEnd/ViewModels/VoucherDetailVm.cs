using Bs.VoucherModule.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.VoucherModule.FrontEnd.ViewModels
{
    public class VoucherDetailVm : ObservableObject
    {
        public Voucher Voucher { get; set; }

        public VoucherDetailVm(Voucher voucher)
        {
            Voucher = voucher;
        }




    }
}
