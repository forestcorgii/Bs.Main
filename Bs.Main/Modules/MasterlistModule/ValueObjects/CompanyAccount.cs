using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.MasterlistModule.ValueObjects
{
    public class CompanyAccount
    {
        public int Id { get; set; }
        public string CompanyId { get; set; }

        public string BankName { get; set; }
        public string Code { get; set; }
        public string AccountNumber { get; set; }


        public DateTime DateCreated { get; set; }

        public CompanyAccount() { }
        public CompanyAccount(string bankName, string code, string accountNumber)
        {
            BankName = bankName;
            Code = code;
            AccountNumber = accountNumber;
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(BankName))
                throw new Exception($"{nameof(BankName)} should not be blank.");
            if (string.IsNullOrEmpty(Code))
                throw new Exception($"{nameof(Code)} should not be blank.");
            if (string.IsNullOrEmpty(AccountNumber))
                throw new Exception($"{nameof(AccountNumber)} should not be blank.");
        }

        public override string ToString()
        {
            return $"{Code} - {BankName}";
        }
    }
}
