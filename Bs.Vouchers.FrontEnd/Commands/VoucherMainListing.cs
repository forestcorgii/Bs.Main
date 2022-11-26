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
    public class VoucherMainListing : CommandBase
    {
        private Companies Companies;
        private JournalAccounts JournalAccounts;

        private MainVm Vm;

        public VoucherMainListing(MainVm vm, Companies companies, JournalAccounts journalAccounts) : base(vm)
        {
            Companies = companies;
            Vm = vm;
            JournalAccounts = journalAccounts;
        }

        public async override void Execute(object parameter)
        {
            IEnumerable<Company> companies = new List<Company>();
            IEnumerable<JournalAccount> journalAccounts = new List<JournalAccount>();

            await Task.Run(() =>
            {
                companies = Companies.Get().Select(c => (Company)c);
                journalAccounts = JournalAccounts.Get().Select(c => (JournalAccount)c);
            });

            Vm.Companies = companies;
            Vm.JournalAccounts = journalAccounts;

            Vm.SelectedCompany = companies.FirstOrDefault();
        }
    }
}
