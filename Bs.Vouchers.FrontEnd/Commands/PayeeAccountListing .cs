using Bs.Common;
using Bs.Common.Commands;
using Bs.Main.Modules.MasterlistModule.Models;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using Bs.Vouchers.FrontEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Vouchers.FrontEnd.Commands
{
    public class PayeeAccountListing : CommandBase
    {
        private PayeeAccounts PayeeAccounts;

        private MainVm Vm;

        public PayeeAccountListing(MainVm vm, PayeeAccounts payeeAccounts) : base(vm)
        {
            Vm = vm;
            PayeeAccounts = payeeAccounts;
        }

        public async override void Execute(object parameter)
        {
            IEnumerable<PayeeAccount> payeeAccounts = new List<PayeeAccount>();

            await Task.Run(() =>
            {
                payeeAccounts = PayeeAccounts.Get().Select(c => (PayeeAccount)c);
                if (parameter is string searchInput && searchInput != string.Empty)
                    payeeAccounts = payeeAccounts.Where(p => p.AccountNumber.Contains(searchInput) ||
                            p.Payee.PayeeName.Contains(searchInput));
            });

            Vm.PayeeAccounts = payeeAccounts;
            Vm.SelectedPayeeAccount = payeeAccounts.FirstOrDefault();
        }
    }
}
