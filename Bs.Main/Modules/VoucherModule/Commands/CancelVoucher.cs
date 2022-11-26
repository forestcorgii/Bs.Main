using Bs.Common;
using Bs.Common.Commands;
using Bs.Main.Modules.VoucherModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.VoucherModule.Commands
{
    public class CancelVoucher : CommandBase
    {
        public VoucherListingVm Vm;
        public CancelVoucher(VoucherListingVm vm) : base(vm)
        {
            Vm = vm;
        }

        public override void Execute(object parameter)
        {
        }
    }
}
