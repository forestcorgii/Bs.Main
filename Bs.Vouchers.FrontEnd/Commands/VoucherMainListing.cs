using Bs.Common;
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
    public class VoucherMainListing : CommandBase
    {
        private Companies Companies;
        private PayeeAccounts PayeeAccounts;

        private MainVm Vm;

        public VoucherMainListing(MainVm vm, Companies companies, PayeeAccounts payeeAccounts) : base(vm)
        {
            Companies = companies;
            Vm = vm;
            PayeeAccounts = payeeAccounts;
        }

        public async override void Execute(object parameter)
        {
            IEnumerable<Company> companies = new List<Company>();
            IEnumerable<CompanyAccount> companyAccounts = new List<CompanyAccount>();
            IEnumerable<Payee> payees = new List<Payee>();
            IEnumerable<PayeeAccount> payeeAccounts = new List<PayeeAccount>();
            IEnumerable<JournalAccount> journalAccounts = new List<JournalAccount>();

            await Task.Run(() =>
            {
                companies = Companies.Get().Select(c => (Company)c);
                //companyAccounts = Companies.Get().Select(c => (CompanyAccount)c);
                //payees = Payees.Get().Select(c => (Payee)c);
                payeeAccounts = PayeeAccounts.Get().Select(c => (PayeeAccount)c);
                //journalAccounts = JournalAccounts.Get().Select(c => (JournalAccount)c);
            });

            Vm.Companies = companies;
            Vm.PayeeAccounts= payeeAccounts;

        }
    }
}
