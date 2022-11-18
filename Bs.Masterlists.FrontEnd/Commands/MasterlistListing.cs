using Bs.Common;
using Bs.Common.Utils;
using Bs.Main.Modules.MasterlistModule.Models;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using Bs.Masterlists.FrontEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Masterlists.FrontEnd.Commands
{
    public class MasterlistListing : CommandBase
    {
        private Companies Companies;
        private CompanyAccounts CompanyAccounts;
        private Payees Payees;
        private PayeeAccounts PayeeAccounts;
        private JournalAccounts JournalAccounts;

        private MasterlistMainVm Vm;

        public MasterlistListing(MasterlistMainVm vm,
            Companies companies,
            CompanyAccounts companyAccounts,
            Payees payees,
            PayeeAccounts payeeAccounts,
            JournalAccounts journalAccounts) : base(vm)
        {
            Companies = companies;
            CompanyAccounts = companyAccounts;
            Payees = payees;
            PayeeAccounts = payeeAccounts;
            JournalAccounts = journalAccounts;

            Vm = vm;
        }


        public async override void Execute(object parameter)
        {
            try
            {
                IEnumerable<Company> companies = new List<Company>();
                IEnumerable<CompanyAccount> companyAccounts = new List<CompanyAccount>();
                IEnumerable<Payee> payees = new List<Payee>();
                IEnumerable<PayeeAccount> payeeAccounts = new List<PayeeAccount>();
                IEnumerable<JournalAccount> journalAccounts = new List<JournalAccount>();

                await Task.Run(() =>
                {
                    companies = Companies.Get().Select(c => (Company)c);
                    companyAccounts = Companies.Get().Select(c => (CompanyAccount)c);
                    payees = Payees.Get().Select(c => (Payee)c);
                    payeeAccounts = PayeeAccounts.Get().Select(c => (PayeeAccount)c);
                    journalAccounts = JournalAccounts.Get().Select(c => (JournalAccount)c);
                });

                Vm.Companies = companies;
                Vm.Payees = payees;

            }
            catch (Exception ex) { MessageBoxes.Error(ex.Message); }
        }
    }
}
